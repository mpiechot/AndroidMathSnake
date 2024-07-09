#nullable enable

using System.Collections;
using UnityEngine;
using TMPro;
using System;

namespace MathSnake.Snake
{
    /// <summary>
    /// Represents the movement of a snake body.
    /// </summary>
    public class SnakeBodyMovement : MonoBehaviour
    {
        [SerializeField] private SnakeSettings snakeSettings;
        [SerializeField] private TextMeshPro number;

        public Transform? target { get; set; }
        

        private void Awake()
        {
            _ = snakeSettings ?? throw new ArgumentNullException(nameof(snakeSettings));
        }

        private void Update()
        {
            if (target == null)
            {
                Debug.LogError($"Target of {name} is null!");
                return;
            }

            float distance = Vector3.Distance(transform.position, target.position);
            if (distance > snakeSettings.PartsDistance)
            {
                transform.Translate(Vector3.forward * distance * snakeSettings.CurrentSpeed * Time.deltaTime, Space.Self);
                transform.LookAt(target);
            }
        }
    }
}
