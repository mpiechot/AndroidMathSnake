using System.Collections.Generic;
using UnityEngine;

namespace MathSnake.Extensions
{
    public static class BoundsIntExtensions
    {
        /// <summary>
        ///     Converts a BoundsInt.PositionEnumerator to an IEnumerable<Vector3Int>.
        /// </summary>
        /// <param name="enumerator">The PositionEnumerator to convert.</param>
        /// <returns>An IEnumerable<Vector3Int> that can be used with LINQ.</returns>
        public static IEnumerable<Vector3Int> AsEnumerable(this BoundsInt.PositionEnumerator enumerator)
        {
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }
    }
}