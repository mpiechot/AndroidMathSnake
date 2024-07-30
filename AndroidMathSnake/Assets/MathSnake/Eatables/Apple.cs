#nullable enable

using MathSnake.Eatables.States;
using MathSnake.Exceptions;
using TMPro;
using UnityEngine;

namespace MathSnake.Eatables
{
    [RequireComponent(typeof(Rotting))]
    public class Apple : MonoBehaviour, IEatable
    {
        [SerializeField]
        private ParticleSystem? eatingParticles;

        [SerializeField]
        private TMP_Text? numberLabel;

        [SerializeField]
        private MeshRenderer? meshRenderer;

        [SerializeField]
        private Rotting? rotting;

        private Rotting Rotting => SerializeFieldNotAssignedException.ThrowIfNull(rotting);

        private TMP_Text NumberLabel => SerializeFieldNotAssignedException.ThrowIfNull(numberLabel);

        /// <summary>
        ///     Gets the number for this apple.
        /// </summary>
        public int Number { get; private set; }

        /// <inheritdoc/>
        public bool IsGameOver => false;

        /// <inheritdoc/>
        public GameObject? GameObject => gameObject == null ? null : gameObject;

        /// <inheritdoc/>
        public bool IsEaten { get; private set; }



        /// <summary>
        ///     Initializes a new instance of the <see cref="Apple"/> class.
        /// </summary>
        /// <param name="number">The number the apple should display.</param>
        /// <param name="context">The game context.</param>
        public void Initialize(int number, GameContext context)
        {
            Number = number;
            NumberLabel.text = number.ToString();
            Rotting.Initialize(context.EatableSettings);
            Rotting.StartRotting();
        }

        /// <inheritdoc/>
        public void Eat()
        {
            IsEaten = true;
            Instantiate(eatingParticles, transform.position, Quaternion.Euler(-90, 0, 0));
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            Instantiate(eatingParticles, transform.position, Quaternion.Euler(-90, 0, 0));
        }
    }
}
