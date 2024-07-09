#nullable enable

using UnityEngine;

namespace MathSnake.Eatables
{
    /// <summary>
    /// This class describes settings for a in game snake.
    /// </summary>
    [CreateAssetMenu(fileName = "RottingSettings", menuName = "ScriptableObjects/RottingSettings", order = 1)]
    public class RottingSettings : ScriptableObject
    {
        /// <summary>
        /// Gets the Color of a fresh apple.
        /// </summary>
        [field: ColorUsage(false)]
        public Color FreshColor { get; } = Color.white;

        /// <summary>
        /// Gets the Color of a good apple.
        /// </summary>
        [field: ColorUsage(false)]
        public Color GoodColor { get; } = Color.yellow;

        /// <summary>
        /// Gets the Color of a dead apple.
        /// </summary>
        [field: ColorUsage(false)]
        public Color DeadColor { get; } = new Color(0, 255, 172);

        /// <summary>
        /// Gets the size of a fresh apple. 
        /// This represents the scale of the apple when it is in its freshest state.
        /// </summary>
        [field: SerializeField]
        public float FreshSize { get; } = 2f;

        /// <summary>
        /// Gets the size of a dead apple. 
        /// This represents the scale of the apple when it has completely rotted.
        /// </summary>
        [field: SerializeField]
        public float DeadSize { get; } = 1.5f;

        /// <summary>
        /// Gets the speed at which an apple rots. 
        /// This is a value between 0 and 1, where 1 represents the fastest possible rotting speed.
        /// </summary>
        [field: SerializeField, Range(0, 1)]
        public float RottingSpeed { get; }

    }
}
