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
        private SnakeSettings? snakeSettings;

        private Transform? target;

        private float currentSpeed;

        /// <summary>
        ///    Gets the target to follow.
        /// </summary>
        public Transform Target => NotInitializedException.ThrowIfNull(target);

        private SnakeSettings SnakeSettings => NotInitializedException.ThrowIfNull(snakeSettings);

        /// <summary>
        ///     Initializes a new instance of the <see cref="SnakeBodyBase"/> class.
        /// </summary>
        /// <param name="speed">The movement speed of the snake body part.</param>
        /// <param name="followTarget">The target for the snake body part to follow.</param>
        /// <param name="settings">The settings to be used by the snake body part.</param>
        public void Initialize(float speed, Transform followTarget, SnakeSettings settings)
        {
            snakeSettings = settings;
            currentSpeed = speed;
            UpdateTarget(followTarget);
        }

        /// <summary>
        ///     Updates the target that this snake body part should follow.
        /// </summary>
        /// <param name="newTarget">The new target for the snake body part to follow.</param>
        public void UpdateTarget(Transform newTarget)
        {
            target = newTarget;
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
                transform.Translate(Vector3.forward * distance * currentSpeed * Time.deltaTime, Space.Self);
                transform.LookAt(target);
            }
        }
    }
}
