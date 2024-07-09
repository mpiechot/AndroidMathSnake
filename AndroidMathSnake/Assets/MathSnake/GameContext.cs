#nullable enable

using MathSnake.Eatables;
using MathSnake.Snake;

namespace MathSnake
{
    /// <summary>
    ///     Represents the context of the game, holding global settings and states that affect game behavior.
    ///     This includes settings for features such as rotting mechanics for items in the game.
    /// </summary>
    public class GameContext
    {
        /// <summary>
        ///     Gets the settings related to the rotting behavior of items within the game.
        /// </summary>
        public RottingSettings RottingSettings { get; }

        /// <summary>
        ///    Gets the settings related to the snake behavior within the game.
        /// </summary>
        public SnakeSettings SnakeSettings { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameContext"/> class with specified rotting settings.
        /// </summary>
        /// <param name="rottingSettings">The rotting settings to be used within the game context.</param>
        public GameContext(RottingSettings rottingSettings, SnakeSettings snakeSettings)
        {
            RottingSettings = rottingSettings;
            SnakeSettings = snakeSettings;
        }
    }
}

