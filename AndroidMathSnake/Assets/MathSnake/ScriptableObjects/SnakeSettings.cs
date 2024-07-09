#nullable enable

using UnityEngine;

namespace MathSnake.Snake
{
    /// <summary>
    /// This class describes settings for a in game snake.
    /// </summary>
    [CreateAssetMenu(fileName = "SnakeSettings", menuName = "ScriptableObjects/SnakeSettings", order = 1)]
    public class SnakeSettings : ScriptableObject
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float increaseSpeedBy = .3f;
        [SerializeField] private float rotationSpeed = 150f;
        [SerializeField] private float increaseRotationBy = 5f;
        [SerializeField] private float partsDistance = 1f;


        /// <summary>
        /// Gets or sets the speed for the snake.
        /// </summary>
        public float Speed { get { return speed; } set { speed = value; } }

        /// <summary>
        /// Gets or sets the current speed for the snake.
        /// </summary>
        public float CurrentSpeed { get { return currentSpeed; } set { currentSpeed = value; } }

        /// <summary>
        /// Gets or sets the step value to increase the speed of the snake.
        /// </summary>
        public float IncreaseSpeedBy { get { return increaseSpeedBy; } set { increaseSpeedBy = value; } }

        /// <summary>
        /// Gets or sets the rotationspeed of the snake.
        /// </summary>
        public float RotationSpeed { get { return rotationSpeed; } set { rotationSpeed = value; } }

        /// <summary>
        /// Gets or sets the current rotationSpeed for the snake.
        /// </summary>
        public float CurrentRotation { get { return currentRotation; } set { currentRotation = value; } }

        /// <summary>
        /// Gets or sets the step value to increase the rotation speed.
        /// </summary>
        public float IncreaseRotationBy { get { return increaseRotationBy; } set { increaseRotationBy = value; } }

        /// <summary>
        /// Gets or sets the distance between snake parts.
        /// </summary>
        public float PartsDistance { get { return partsDistance; } set { partsDistance = value; } }
    }
}
