#nullable enable

using UnityEngine;

namespace MathSnake.Player
{
    /// <summary>
    ///     Holds configuration settings for the snake in the game. This includes prefabs for different parts of the snake,
    ///     initial movement speed, rotation speed, and other gameplay-related settings. This scriptable object allows for easy
    ///     adjustments to the snake's behavior and appearance within the Unity Editor.
    /// </summary>
    [CreateAssetMenu(fileName = "SnakeSettings", menuName = "MathSnake/Snake/Snake Settings", order = 1)]
    public class SnakeSettings : ScriptableObject
    {
        /// <summary>
        ///     Gets the prefab for spawning a snake.
        /// </summary>
        [field: SerializeField]
        public Snake SnakePrefab { get; private set; } = null!;

        /// <summary>
        ///     Gets the prefab for spawning a snake body part without a number.
        /// </summary>
        [field: SerializeField]
        public SnakeBodyBase SnakeBodyPrefab { get; private set; } = null!;

        /// <summary>
        ///     Gets the prefab for spawning a snake body part with a number.
        /// </summary>
        [field: SerializeField]
        public NumberedSnakeBody NumberedSnakeBodyPrefab { get; private set; } = null!;

        /// <summary>
        ///     Gets the prefab for spawning a snake's tail.
        /// </summary>
        [field: SerializeField]
        public SnakeBodyBase SnakeTailPrefab { get; private set; } = null!;

        /// <summary>
        ///     Gets the initial speed for the snake.
        /// </summary>
        [field: SerializeField]
        public float InitialSpeed { get; private set; }

        /// <summary>
        ///     Gets the value to increase the speed of the snake by, when it eats a valid item.
        /// </summary>
        [field: SerializeField]
        public float IncreaseSpeedBy { get; private set; } = .3f;

        /// <summary>
        ///     Gets the speed at which the snake rotates.
        /// </summary>
        [field: SerializeField]
        public float RotationSpeed { get; private set; } = 150f;

        /// <summary>
        ///     Gets the step value to increase the rotation speed.
        /// </summary>
        [field: SerializeField]
        public float IncreaseRotationSpeedBy { get; private set; } = 5f;

        /// <summary>
        ///     Gets the gap between snake parts.
        /// </summary>
        [field: SerializeField]
        public float SnakePartsGap { get; private set; } = 1f;
    }
}
