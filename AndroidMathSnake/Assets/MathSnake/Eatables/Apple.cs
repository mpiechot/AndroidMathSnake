#nullable enable

using MathSnake.Eatables.States;
using MathSnake.Exceptions;
using UnityEngine;

namespace MathSnake.Eatables
{
    [RequireComponent(typeof(Rotting))]
    public class Apple : MonoBehaviour, IEatable
    {
        [SerializeField]
        private GameObject? eatingParticles;

        [SerializeField]
        private MeshRenderer? meshRenderer;

        [SerializeField]
        private Rotting? rotting;

        private Rotting Rotting => SerializeFieldNotAssignedException.ThrowIfNull(rotting);

        /// <summary>
        ///     Gets the number for this apple.
        /// </summary>
        public int Number { get; private set; }

        /// <inheritdoc/>
        public bool IsGameOver => false;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Apple"/> class.
        /// </summary>
        /// <param name="number">The number the apple should display.</param>
        /// <param name="context">The game context.</param>
        public void Initialize(int number, GameContext context)
        {
            Number = number;
            Rotting.Initialize(context.RottingSettings);
            Rotting.StartRotting();
        }

        /// <inheritdoc/>
        public void Eat()
        {
            Instantiate(eatingParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
