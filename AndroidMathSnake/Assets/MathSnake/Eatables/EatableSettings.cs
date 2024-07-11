#nullable enable

using UnityEngine;

namespace MathSnake.Eatables
{
    [CreateAssetMenu(fileName = "EatableSettings", menuName = "MathSnake/Eatables/Eatable Settings", order = 1)]
    public class EatableSettings : ScriptableObject
    {
        /// <summary>
        ///     Gets the prefab of an apple.
        /// </summary>
        [field: SerializeField]
        public Apple ApplePrefab { get; private set; } = null!;

        /// <summary>
        ///     Gets the Color of a fresh apple.
        /// </summary>
        [field: SerializeField, ColorUsage(false)]
        public Color FreshColor { get; private set; } = Color.white;

        /// <summary>
        ///     Gets the Color of a good apple.
        /// </summary>
        [field: SerializeField, ColorUsage(false)]
        public Color GoodColor { get; private set; } = Color.yellow;

        /// <summary>
        ///     Gets the Color of a dead apple.
        /// </summary>
        [field: SerializeField, ColorUsage(false)]
        public Color DeadColor { get; private set; } = new Color(0, 255, 172);

        /// <summary>
        ///     Gets the size of a fresh apple. 
        ///     This represents the scale of the apple when it is in its freshest state.
        /// </summary>
        [field: SerializeField]
        public float FreshSize { get; private set; } = 2f;

        /// <summary>
        ///     Gets the size of a dead apple. 
        ///     This represents the scale of the apple when it has completely rotted.
        /// </summary>
        [field: SerializeField]
        public float DeadSize { get; private set; } = 1.5f;

        /// <summary>
        ///     Gets the speed at which an apple rots. 
        ///     This is a value between 0 and 1, where 1 represents the fastest possible rotting speed.
        /// </summary>
        [field: SerializeField, Range(0, 1)]
        public float RottingSpeed { get; private set; }

    }
}
