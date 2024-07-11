#nullable enable

using MathSnake.Exceptions;
using MathSnake.Player;
using UnityEngine;

namespace MathSnake
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField]
        private GameSettings? gameSettings;

        private GameSettings GameSettings => SerializeFieldNotAssignedException.ThrowIfNull(gameSettings);

        private void Start()
        {
            var gameContext = new GameContext(GameSettings);

            var snake = SnakeSpawner.SpawnSnake(gameContext);
            gameContext.Player = snake;
        }
    }
}
