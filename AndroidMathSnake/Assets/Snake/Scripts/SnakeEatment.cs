#nullable enable

using System;
using UnityEngine;

namespace MathSnake.Snake
{
    public class SnakeEatment : MonoBehaviour
    {
        [SerializeField] private AudioSource eatingSound;

        public event EventHandler<int>? AppleEatenEvent;
        public event EventHandler? WallEatenEvent;

        void OnTriggerEnter(Collider col)
        {
            if (col.tag == "Apple" && col.TryGetComponent<Apple>(out var apple))
            {
                if(eatingSound != null)
                {
                    eatingSound.Play();
                }

                AppleEatenEvent?.Invoke(this, apple.num);
                Destroy(col.gameObject);
            }
            else if(col.tag == "Wall")
            {
                WallEatenEvent?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}