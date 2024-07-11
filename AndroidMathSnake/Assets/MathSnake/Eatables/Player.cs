using UnityEngine;

namespace MathSnake.Eatables
{
    public class Player : MonoBehaviour, IEatable
    {
        /// <inheritdoc/>
        public bool IsGameOver => true;

        /// <inheritdoc/>
        public GameObject GameObject => gameObject;

        /// <inheritdoc/>
        public void Eat()
        {
            // Do nothing, because the player is not edible => Game over.
        }
    }
}
