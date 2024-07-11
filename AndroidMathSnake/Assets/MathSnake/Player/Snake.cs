#nullable enable

using MathSnake.Eatables;
using MathSnake.Exceptions;
using MathSnake.Extensions;
using System;
using UnityEngine;

namespace MathSnake.Player
{
    /// <summary>
    ///     Represents a snake in the game.
    /// </summary>
    [RequireComponent(typeof(SnakeHeadMovement))]
    public class Snake : MonoBehaviour
    {
        [SerializeField]
        private AudioSource? dieSound;

        [SerializeField]
        private Transform? snakeBodyParent;

        [SerializeField]
        private Transform? snakeHead;

        private SnakeHeadMovement? snakeMovement;

        private GameContext? gameContext;

        private SnakeMouth? snakeMouth;

        private SnakeBodyController? snakeBodyController;

        public SnakeHeadMovement SnakeMovement => NotInitializedException.ThrowIfNull(snakeMovement);

        public SnakeMouth SnakeMouth => NotInitializedException.ThrowIfNull(snakeMouth);

        public SnakeBodyController SnakeBodyController => NotInitializedException.ThrowIfNull(snakeBodyController);

        private GameContext GameContext => NotInitializedException.ThrowIfNull(gameContext);

        private AudioSource DieSound => SerializeFieldNotAssignedException.ThrowIfNull(dieSound);

        private Transform SnakeBodyParent => SerializeFieldNotAssignedException.ThrowIfNull(snakeBodyParent);

        private Transform SnakeHead => SerializeFieldNotAssignedException.ThrowIfNull(snakeHead);

        /// <summary>
        ///     Occurs when the snake dies.
        /// </summary>
        public event EventHandler<DieEventArgs>? Died;


        //private int currentNums { get; set; }


        /// <summary>
        ///     Initializes a new instance of the <see cref="Snake"/> class.
        /// </summary>
        /// <param name="context">The game context to use.</param>
        public void Initialize(GameContext context)
        {
            gameContext = context;

            snakeMouth = gameObject.GetComponentInChildrenOrThrow<SnakeMouth>();
            snakeMouth.Initialize(context.SnakeSettings);

            snakeMovement = gameObject.GetComponentOrThrow<SnakeHeadMovement>();
            SnakeMovement.Initialize(SnakeHead, context.SnakeSettings);

            SnakeMouth.Eaten += OnEatenTriggered;

            SnakeMovement.StartMovement();

            snakeBodyController = new(SnakeHead, SnakeBodyParent, context);
        }
        private void IncreaseSpeed()
        {
            SnakeMovement.IncreaseSpeed();
        }

        private void OnEatenTriggered(object sender, EatenEventArgs args)
        {
            if (args.EatenItem.IsGameOver)
            {
                DieSound.Play();
                SnakeMovement.StopMovement();
                Debug.Log("Snake hit a Wall");
                //PlayerValues.Score = Int32.Parse(GameMaster.gm.currentScore.text);
                //StartCoroutine(StartUIControll.focusOn());
                //SceneManager.LoadScene("UpdateHighScore");
                Destroy(gameObject);
                return;
            }

            if (args.EatenItem is Apple apple)
            {
                //TextMeshProUGUI search = gm.searchNumberField;
                //if (search.text[search.text.Length - 2] == '=')
                //{
                //    search.text += apple.num;
                //}
                //else
                //{
                //    search.text += " + " + apple.num;
                //}
                //gm.searchNumberField.text += "";
                Debug.Log($"Snake eat apple with number {apple.Number}");
                SnakeBodyController.CreateBodyPart(apple.Number);

                IncreaseSpeed();
            }
        }

        private void OnDestroy()
        {
            SnakeMouth.Eaten -= OnEatenTriggered;

            foreach (Transform bodyPart in SnakeBodyParent)
            {
                Destroy(bodyPart.gameObject);
            }
        }
    }
}
