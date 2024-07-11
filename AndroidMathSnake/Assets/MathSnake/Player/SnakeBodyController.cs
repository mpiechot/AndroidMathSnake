#nullable enable

using System.Collections.Generic;
using UnityEngine;

namespace MathSnake.Player
{
    /// <summary>
    ///     Represents a controller for the snakes body for adding and removing new parts.
    /// </summary>
    public class SnakeBodyController
    {
        private readonly Transform bodyParent;

        private readonly SnakeBodyBase tail;

        private readonly List<Transform> bodyParts = new List<Transform>();

        private readonly GameContext context;

        private SnakeSettings SnakeSettings => context.SnakeSettings;

        private Transform nextFollowTarget;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SnakeBodyController"/> class.
        /// </summary>
        /// <param name="snakeHead">The head of the snake.</param>
        /// <param name="bodyParent">The parent object for all created body parts.</param>
        /// <param name="context">The game context to use.</param>
        public SnakeBodyController(Transform snakeHead, Transform bodyParent, GameContext context)
        {
            this.context = context;
            this.bodyParent = bodyParent;

            tail = GameObject.Instantiate(SnakeSettings.SnakeTailPrefab, snakeHead.position, snakeHead.rotation, bodyParent);
            tail.Initialize(SnakeSettings.InitialSpeed, snakeHead, SnakeSettings);
            bodyParts.Add(tail.transform);

            nextFollowTarget = snakeHead;
        }

        /// <summary>
        ///     Creates a new body part for the snake.
        ///     Note: The body part will be created without a number.
        /// </summary>
        public void CreateBodyPart()
        {
            var bodyPart = GameObject.Instantiate(SnakeSettings.SnakeBodyPrefab, tail.transform.position, tail.transform.rotation, bodyParent);
            bodyPart.Initialize(context.Player.SnakeMovement.CurrentSpeed, nextFollowTarget, SnakeSettings);
            bodyPart.name = $"BodyPart {bodyParts.Count}";
            bodyParts.Add(bodyPart.transform);
            nextFollowTarget = bodyPart.transform;
            tail.UpdateTarget(bodyPart.transform);


            //Print the eaten number on the bodyPart if not 0
            //if (num != 0)
            //{
            //    TextMeshPro mesh = bpm.GetComponentInChildren<TextMeshPro>();
            //    mesh.text = num.ToString();
            //    currentNums += num;
            //}
        }

        /// <summary>
        ///    Creates a new body part for the snake with a specified number.
        /// </summary>
        /// <param name="num">The number to assign to the created body part.</param>
        public void CreateBodyPart(int num)
        {
            var bodyPart = GameObject.Instantiate(SnakeSettings.NumberedSnakeBodyPrefab, tail.transform.position, tail.transform.rotation, bodyParent);
            bodyPart.Initialize(num, context.Player.SnakeMovement.CurrentSpeed, nextFollowTarget, SnakeSettings);
            bodyPart.name = $"BodyPart {bodyParts.Count} ({num})";
            bodyParts.Add(bodyPart.transform);
            nextFollowTarget = bodyPart.transform;
            tail.UpdateTarget(bodyPart.transform);


            //Print the eaten number on the bodyPart if not 0
            //if (num != 0)
            //{
            //    TextMeshPro mesh = bpm.GetComponentInChildren<TextMeshPro>();
            //    mesh.text = num.ToString();
            //    currentNums += num;
            //}
        }
    }
}
