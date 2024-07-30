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
    public class SnakeTestGameController : MonoBehaviour, IGameController
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

            snake.SnakeBodyController.CreateBodyPart();
            snake.SnakeBodyController.CreateBodyPart();
            snake.SnakeBodyController.CreateBodyPart();
            snake.SnakeBodyController.CreateBodyPart();
            snake.SnakeBodyController.CreateBodyPart();
            snake.SnakeBodyController.CreateBodyPart();


            gameIsRunning = true;
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

        private void GameOver()
        {
            gameIsRunning = false;
            Context.UiController.ShowGameOver();
        }

        public StomachResult EvaluateStomach(IEatable eatable)
        {
            // Nothing to evaluate here
            return StomachResult.Grow;
        }
    }
}

