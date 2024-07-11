#nullable enable

using MathSnake.Extensions;
using UnityEngine;

namespace MathSnake.Eatables
{
    /// <summary>
    ///     Represents a class that is responsible for spawning eatables.
    /// </summary>
    public static class EatablesSpawner
    {
        /// <summary>
        ///     Spawns an apple with the given number at the given position.
        /// </summary>
        /// <param name="number">The number, which should be assigned to the created apple.</param>
        /// <param name="position">The position to spawn the apple at.</param>
        /// <returns>The newly created apple.</returns>
        public static Apple SpawnApple(int number, GameContext gameContext, Transform parent)
        {
            var position = gameContext.TilemapController.GetRandomTilePosition();
            var spawnedApple = GameObject.Instantiate(gameContext.EatableSettings.ApplePrefab, position, Quaternion.identity, parent);
            spawnedApple.Initialize(number, gameContext);
            spawnedApple.gameObject.name = $"Apple ({number})";

            return spawnedApple;
        }
    }
}
