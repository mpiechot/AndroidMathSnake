#nullable enable

using MathSnake.Exceptions;
using System;
using UnityEngine;

namespace MathSnake.Player
{
    /// <summary>
    /// Represents the movement of a snake body.
    /// </summary>
    public class SnakeBodyBase : MonoBehaviour
    {
        private SnakeSettings? snakeSettings;

        private Transform? target;

        private float currentSpeed;

        private SnakeSettings SnakeSettings => NotInitializedException.ThrowIfNull(snakeSettings);

        public void Initialize(float speed, Transform nextFollowTarget, SnakeSettings settings)
        {
            snakeSettings = settings;
            currentSpeed = speed;
            UpdateTarget(nextFollowTarget);
        }

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
            if (distance > SnakeSettings.PartsDistance)
            {
                transform.Translate(Vector3.forward * distance * currentSpeed * Time.deltaTime, Space.Self);
                transform.LookAt(target);
            }
        }
    }
}
