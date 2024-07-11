#nullable enable

using MathSnake.Assets.MathSnake;
using MathSnake.Eatables;
using MathSnake.Exceptions;
using MathSnake.Player;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MathSnake
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private Transform? eatablesParent;

        private DifficultyManager difficultyManager = new();

        private GameContext? context;

        private List<IEatable> eatables = new();

        private bool gameIsRunning;

        private int currentSearchNumber;
        private int currentLevel = 0;
        private int currentScore = 0;

        //private CameraShaker cameraShaker;

        private Transform EatablesParent => SerializeFieldNotAssignedException.ThrowIfNull(eatablesParent);

        private GameContext Context => GameNotStartedException.ThrowIfNull(context);

        /// <summary>
        ///    Gets the current search number.
        /// </summary>
        public int CurrentSearchNumber => currentSearchNumber;

        public void StartGame(GameContext gameContext)
        {
            context = gameContext;

            // Start the background music
            gameContext.BackgroundMusicController.StartBackgroundMusic();

            // Setup the current score
            gameContext.UiController.UpdateScore(currentScore);

            // Spawn the snake
            var snake = SnakeSpawner.SpawnSnake(gameContext);
            snake.Died += OnSnakeDied;
            gameContext.Player = snake;

            // Select the first apple number
            currentSearchNumber = Random.Range(2, 10);
            gameContext.UiController.UpdateSearchNumber(currentSearchNumber);

            // Spawn the first apples
            SpawnApplePairs(2);

            gameIsRunning = true;
        }

        private void SpawnApplePairs(int ammount = 1)
        {
            for (int i = 0; i < ammount; i++)
            {
                int firstNum = Random.Range(1, currentSearchNumber);
                eatables.Add(EatablesSpawner.SpawnApple(firstNum, Context, EatablesParent));
                eatables.Add(EatablesSpawner.SpawnApple(currentSearchNumber - firstNum, Context, EatablesParent));
            }
        }

        private void OnSnakeDied(object sender, DieEventArgs args)
        {
            gameIsRunning = false;
        }

        private void OnDestroy()
        {
            foreach (var item in eatables)
            {
                GameObject.Destroy(item.GameObject);
            }
        }

        private void IncreaseScore()
        {
            currentScore += 10;
            Context.UiController.UpdateScore(currentScore);
        }

        public StomachResult EvaluateStomach(IEatable eatable)
        {
            if (eatable.IsGameOver)
            {
                GameOver();
                return StomachResult.Die;
            }

            if (Context.Player.SnakeBodyController.LastAddedNumber == null)
            {
                return StomachResult.Grow;
            }

            if (eatable is Apple apple)
            {
                var firstNumber = Context.Player.SnakeBodyController.LastAddedNumber.Number;
                var secondNumber = apple.Number;
                if (firstNumber + secondNumber == CurrentSearchNumber)
                {
                    IncreaseScore();
                    Context.Player.SnakeBodyController.DestroyLastBodyPart();
                    foreach (var item in eatables)
                    {
                        GameObject.Destroy(item.GameObject);
                    }
                    eatables.Clear();

                    currentSearchNumber = Random.Range(2, 10);
                    Context.UiController.UpdateSearchNumber(currentSearchNumber);
                    SpawnApplePairs(2);
                    return StomachResult.Shrink;
                }
            }

            if (eatables.All(eatables => eatables.IsEaten))
            {
                GameOver();
                return StomachResult.Die;
            }

            return StomachResult.Grow;
        }

        private void GameOver()
        {
            gameIsRunning = false;
            Context.UiController.ShowGameOver();
        }
    }
}

