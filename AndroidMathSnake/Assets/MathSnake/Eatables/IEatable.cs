#nullable enable

using UnityEngine;

namespace MathSnake.Eatables
{
    public interface IEatable
    {
        /// <summary>
        ///    Gets a value indicating whether the game is over after eating this item.
        /// </summary>
        bool IsGameOver { get; }

        /// <summary>
        ///    Gets or sets a value indicating whether the item is eaten.
        /// </summary>
        bool IsEaten { get; }

        /// <summary>
        ///     Gets the game object of the eatable item in the scene.
        /// </summary>
        GameObject? GameObject { get; }

        /// <summary>
        ///     Eats the item.
        /// </summary>
        void Eat();
    }
}
