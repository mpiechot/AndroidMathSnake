#nullable enable

using MathSnake.Exceptions;
using MathSnake.Extensions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MathSnake
{
    public class TilemapController : MonoBehaviour
    {
        [SerializeField]
        private Tilemap? tilemap;

        private Tilemap Tilemap => SerializeFieldNotAssignedException.ThrowIfNull(tilemap);

        /// <summary>
        ///     Gets all the tile positions in the tilemap.
        /// </summary>
        /// <returns>All the tiles that are occupied in the tilemap.</returns>
        public IEnumerable<Vector3Int> GetAllTilePositions()
        {
            return Tilemap.cellBounds.allPositionsWithin
                .AsEnumerable()
                .Select(cell => new Vector3Int(cell.x, cell.y, cell.z))
                .Where(position => Tilemap.HasTile(position))
                .Select(position => new Vector3Int(position.x, 0, position.y));
        }
    }
}
