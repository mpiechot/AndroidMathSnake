using MathSnake.Extensions;
using UnityEngine;

namespace MathSnake.Player
{
    /// <summary>
    ///     Provides functionality to spawn a snake in the game.
    /// </summary>
    public static class SnakeSpawner
    {
        /// <summary>
        ///     Spawns a new snake instance using the snake prefab defined in the game context's snake settings.
        ///     The new snake is initialized with the provided game context.
        /// </summary>
        /// <param name="context">The game contextto use.</param>
        /// <returns>The newly spawned and initialized snake.</returns>
        public static Snake SpawnSnake(GameContext context)
        {
            var position = context.TilemapController.GetRandomTilePosition();
            var newSnake = GameObject.Instantiate(context.SnakeSettings.SnakePrefab, position, Quaternion.identity);
            newSnake.Initialize(context);
            return newSnake;
        }
    }
}
