#nullable enable

using UnityEngine;

namespace MathSnake.Eatables
{
    public class Wall : MonoBehaviour, IEatable
    {

        /// <inheritdoc/>
        public bool IsGameOver => true;

        /// <inheritdoc/>
        public GameObject GameObject => gameObject;

        /// <inheritdoc/>
        public bool IsEaten { get; private set; }

        /// <inheritdoc/>
        public void Eat()
        {
            // Do nothing, because a wall is not edible => Game over.
        }
    }
}
