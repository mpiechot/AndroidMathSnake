using MathSnake.Eatables;
using System;

namespace MathSnake.Snake
{
    /// <summary>
    ///     Provides data for the event that is raised when an item is eaten by the snake.
    /// </summary>
    public class EatenEventArgs : EventArgs
    {
        /// <summary>
        ///     Gets the item that was eaten.
        /// </summary>
        public IEatable EatenItem { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EatenEventArgs"/> class.
        /// </summary>
        /// <param name="eatenItem">The item that has been eaten.</param>
        public EatenEventArgs(IEatable eatenItem)
        {
            EatenItem = eatenItem;
        }
    }
}

