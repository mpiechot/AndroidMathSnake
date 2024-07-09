#nullable enable

using MathSnake.Eatables;
using System;
using UnityEngine;

namespace MathSnake.Snake
{
    /// <summary>
    /// Represents the eating meachanics of the snake.
    /// </summary>
    public class SnakeMouth : MonoBehaviour
    {
        [SerializeField]
        private AudioSource eatingSound;

        public event EventHandler<EatenEventArgs>? Eaten;

        void OnTriggerEnter(Collider col)
        {
            // TODO Check if this code works and TryGetComponent can also be used with interfaces
            if (/*col.CompareTag("Apple") && */col.TryGetComponent<IEatable>(out var eatable))
            {
                if (eatingSound != null)
                {
                    eatingSound.Play();
                }

                eatable.Eat();

                Eaten?.Invoke(this, new(eatable));
            }
            //else if (col.CompareTag("Wall") && col.TryGetComponent<Wall>(out var wall))
            //{

            //    wall.Eat();

            //    Eaten?.Invoke(this, new(wall));
            //}
        }
    }
}