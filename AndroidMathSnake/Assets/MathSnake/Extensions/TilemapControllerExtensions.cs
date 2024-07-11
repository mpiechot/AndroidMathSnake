using System.Linq;
using UnityEngine;

namespace MathSnake.Extensions
{
    /// <summary>
    ///     Represents a set of extension methods for the <see cref="TilemapController"/> class.
    /// </summary>
    public static class TilemapControllerExtensions
    {
        /// <summary>
        ///     Gets a random tile position from the tilemap.
        /// </summary>
        /// <param name="tilemapController">The tilemap controller to operate on.</param>
        /// <returns>The random position or <see cref="Vector3Int.zero"/> if no tile is occupied.</returns>
        public static Vector3Int GetRandomTilePosition(this TilemapController tilemapController)
        {
            var tilePositions = tilemapController.GetAllTilePositions().ToList();

            if (tilePositions.Count == 0)
            {
                return Vector3Int.zero;
            }

            var randomIndex = Random.Range(0, tilePositions.Count);
            return tilePositions[randomIndex];
        }
    }
}
