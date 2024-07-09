namespace MathSnake.Eatables
{
    public interface IEatable
    {
        /// <summary>
        ///    Gets a value indicating whether the game is over after eating this item.
        /// </summary>
        bool IsGameOver { get; }

        /// <summary>
        ///     Eats the item.
        /// </summary>
        void Eat();
    }
}
