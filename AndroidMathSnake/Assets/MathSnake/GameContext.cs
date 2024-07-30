#nullable enable

using MathSnake.Eatables;
using MathSnake.Exceptions;
using MathSnake.Music;
using MathSnake.Player;
using MathSnake.Ui;

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
        public EatableSettings EatableSettings => gameSettings.RottingSettings;

        /// <summary>
        ///    Gets the settings related to the snake behavior within the game.
        /// </summary>
        public SnakeSettings SnakeSettings => gameSettings.SnakeSettings;

        /// <summary>
        ///    Gets the tilemap controller.
        /// </summary>
        public TilemapController TilemapController { get; }

        /// <summary>
        ///   Gets the UI controller.
        /// </summary>
        public UiController UiController { get; }

        /// <summary>
        ///     Gets the background music controller.
        /// </summary>
        public BackgroundMusicController BackgroundMusicController { get; }

        /// <summary>
        ///    Gets the game master.
        /// </summary>
        public IGameController GameMaster { get; }

        /// <summary>
        ///    Gets or sets the player snake.
        /// </summary>
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
        /// <param name="tilemapController">The tilemap controller to provide.</param>
        /// <param name="musicManager">The music manager to provide.</param>
        /// <param name="uiController">The UI controller to provide.</param>
        /// <param name="gameSettings">The settings to be used within the game context.</param>
        public GameContext(
            IGameController gameMaster,
            TilemapController tilemapController,
            BackgroundMusicController musicManager,
            UiController uiController,
            GameSettings gameSettings)
        {
            GameMaster = gameMaster;
            this.gameSettings = gameSettings;
            UiController = uiController;
            TilemapController = tilemapController;
            BackgroundMusicController = musicManager;
        }
    }
}

