#nullable enable

using UnityEngine;

namespace MathSnake.Player
{
    /// <summary>
    /// This class describes settings for a in game snake.
    /// </summary>
    [CreateAssetMenu(fileName = "SnakeSettings", menuName = "MathSnake/Snake/Snake Settings", order = 1)]
    public class SnakeSettings : ScriptableObject
    {
        /// <summary>
        /// Gets the prefab for spawning a snake.
        /// </summary>
        [field: SerializeField]
        public Snake SnakePrefab { get; private set; } = null!;

        /// <summary>
        /// Gets the prefab for spawning a snake body part.
        /// </summary>
        [field: SerializeField]
        public SnakeBodyBase SnakeBodyPrefab { get; private set; } = null!;

        /// <summary>
        /// Gets the prefab for spawning a snake body part.
        /// </summary>
        [field: SerializeField]
        public NumberedSnakeBody NumberedSnakeBodyPrefab { get; private set; } = null!;

        /// <summary>
        /// Gets the prefab for spawning a snake body part.
        /// </summary>
        [field: SerializeField]
        public SnakeBodyBase SnakeTailPrefab { get; private set; } = null!;

        /// <summary>
        /// Gets the initial speed for the snake.
        /// </summary>
        [field: SerializeField]
        public float InitialSpeed { get; private set; }

        /// <summary>
        /// Gets or sets the step value to increase the speed of the snake.
        /// </summary>
        [field: SerializeField]
        public float IncreaseSpeedBy { get; private set; } = .3f;

        /// <summary>
        /// Gets or sets the rotationspeed of the snake.
        /// </summary>
        [field: SerializeField]
        public float RotationSpeed { get; private set; } = 150f;

        /// <summary>
        /// Gets or sets the step value to increase the rotation speed.
        /// </summary>
        [field: SerializeField]
        public float IncreaseRotationBy { get; private set; } = 5f;

        /// <summary>
        /// Gets or sets the distance between snake parts.
        /// </summary>
        [field: SerializeField]
        public float PartsDistance { get; private set; } = 1f;
    }
}
