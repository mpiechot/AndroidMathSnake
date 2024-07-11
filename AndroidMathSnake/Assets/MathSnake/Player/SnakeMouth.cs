#nullable enable

using MathSnake.Eatables;
using MathSnake.Exceptions;
using System;
using UnityEngine;

namespace MathSnake.Player
{
    /// <summary>
    /// Represents the eating meachanics of the snake.
    /// </summary>
    public class SnakeMouth : MonoBehaviour
    {
        [SerializeField]
        private AudioSource? eatSound;

        private SnakeSettings? snakeSettings;

        public event EventHandler<EatenEventArgs>? Eaten;

        private AudioSource EatingSound => SerializeFieldNotAssignedException.ThrowIfNull(eatSound);

        private SnakeSettings SnakeSettings => NotInitializedException.ThrowIfNull(snakeSettings);

        public void Initialize(SnakeSettings settings)
        {
            snakeSettings = settings;
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.TryGetComponent<IEatable>(out var eatable))
            {
                EatingSound.Play();

                eatable.Eat();

                Eaten?.Invoke(this, new(eatable));
            }
        }
    }
}