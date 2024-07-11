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
            switch (GameContext.GameMaster.EvaluateStomach(args.EatenItem))
            {
                case StomachResult.Grow:
                    // This is save because we know that only apples result in a grow
                    var apple = (Apple)args.EatenItem;
                    SnakeBodyController.CreateBodyPart(apple.Number);
                    IncreaseSpeed();
                    break;
                case StomachResult.Shrink:
                    break;
                case StomachResult.Die:
                    DieSound.Play();
                    SnakeMovement.StopMovement();
                    Destroy(gameObject);
                    break;
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
