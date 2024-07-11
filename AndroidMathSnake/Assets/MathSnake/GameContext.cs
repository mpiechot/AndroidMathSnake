#nullable enable

using MathSnake.Eatables;
using MathSnake.Exceptions;
using MathSnake.Player;

namespace MathSnake
{
    /// <summary>
    ///     Represents the context of the game, holding global settings and states that affect game behavior.
    ///     This includes settings for features such as rotting mechanics for items in the game.
    /// </summary>
    public class GameContext
    {
        private GameSettings gameSettings;

        private Snake? player;

        /// <summary>
        ///     Gets the settings related to the rotting behavior of items within the game.
        /// </summary>
        public RottingSettings RottingSettings => gameSettings.RottingSettings;

        /// <summary>
        ///    Gets the settings related to the snake behavior within the game.
        /// </summary>
        public SnakeSettings SnakeSettings => gameSettings.SnakeSettings;

        public Snake Player
        {
            get
            {
                return NotAssignedException.ThrowIfNull(player);
            }
            set
            {
                player = value;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameContext"/> class with specified rotting settings.
        /// </summary>
        /// <param name="gameSettings">The settings to be used within the game context.</param>
        public GameContext(GameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
        }
    }
}

