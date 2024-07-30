#nullable enable

using MathSnake.Exceptions;
using System;
using UnityEngine;

namespace MathSnake.Player
{
    /// <summary>
    ///     Represents a base component of a snake's body in the game.
    ///     This class handles the movement and targeting logic for each body part.
    /// </summary>
    public class SnakeBodyBase : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody? bodyPartRigidbody;

        private SnakeSettings? snakeSettings;

        private SnakeHeadMovement? snakeHeadMovement;

        private Rigidbody? target;

        private float CurrentSpeed => SnakeHeadMovement.CurrentSpeed;

        /// <summary>
        ///    Gets the target to follow.
        /// </summary>
        public Rigidbody Target => NotInitializedException.ThrowIfNull(target);

        private SnakeSettings SnakeSettings => NotInitializedException.ThrowIfNull(snakeSettings);

        private SnakeHeadMovement SnakeHeadMovement => NotInitializedException.ThrowIfNull(snakeHeadMovement);


        /// <summary>
        ///     Gets the rigidbody of the snake body part.
        /// </summary>
        public Rigidbody BodyPartRigidbody => SerializeFieldNotAssignedException.ThrowIfNull(bodyPartRigidbody);

        /// <summary>
        ///     Initializes a new instance of the <see cref="SnakeBodyBase"/> class.
        /// </summary>
        /// <param name="snakeHead">The movement speed of the snake body part.</param>
        /// <param name="followTarget">The target for the snake body part to follow.</param>
        /// <param name="settings">The settings to be used by the snake body part.</param>
        public void Initialize(SnakeHeadMovement snakeHead, Rigidbody followTarget, SnakeSettings settings)
        {
            snakeSettings = settings;
            snakeHeadMovement = snakeHead;
            ConnectTo(followTarget);
        }

        /// <summary>
        ///     Updates the target that this snake body part should follow.
        /// </summary>
        /// <param name="newTarget">The new target for the snake body part to follow.</param>
        public void ConnectTo(Rigidbody newTarget)
        {
            target = newTarget;
            //BodyPartConntector.connectedBody = newTarget;
        }

        private void Update()
        {
            if (target == null)
            {
                throw new InvalidOperationException("Target is not set. Can't update.");
            }

            float distance = Vector3.Distance(transform.position, target.position);
            if (distance > SnakeSettings.SnakePartsGap)
            {
                transform.LookAt(target.transform);
                transform.Translate(Vector3.forward * distance * CurrentSpeed * Time.deltaTime, Space.Self);
            }
        }
    }
}
