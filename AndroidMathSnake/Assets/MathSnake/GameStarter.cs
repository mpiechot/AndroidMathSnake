#nullable enable

using MathSnake.Exceptions;
using MathSnake.Music;
using MathSnake.Ui;
using UnityEngine;

namespace MathSnake
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField]
        private GameController? gameMaster;

        [SerializeField]
        private GameSettings? gameSettings;

        [SerializeField]
        private TilemapController? tilemapController;

        [SerializeField]
        private BackgroundMusicController? backgroundMusicController;

        [SerializeField]
        private UiController? uiController;

        private void Start()
        {
            SerializeFieldNotAssignedException.ThrowIfNull(gameSettings);
            SerializeFieldNotAssignedException.ThrowIfNull(tilemapController);
            SerializeFieldNotAssignedException.ThrowIfNull(backgroundMusicController);
            SerializeFieldNotAssignedException.ThrowIfNull(uiController);
            SerializeFieldNotAssignedException.ThrowIfNull(gameMaster);

            var gameContext = new GameContext(gameMaster, tilemapController, backgroundMusicController, uiController, gameSettings);

            // Start the game
            gameMaster.StartGame(gameContext);
        }
    }
}
