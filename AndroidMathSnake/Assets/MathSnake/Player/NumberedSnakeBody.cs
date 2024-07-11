#nullable enable

using MathSnake.Exceptions;
using TMPro;
using UnityEngine;

namespace MathSnake.Player
{
    /// <summary>
    ///     Represents a numbered body part of the snake in the game.
    ///     This class extends <see cref="SnakeBodyBase"/> to include functionality for displaying and 
    ///     managing a number associated with the snake body part.
    /// </summary>
    public class NumberedSnakeBody : SnakeBodyBase
    {
        [SerializeField]
        private TMP_Text? numberText;

        public int Number { get; private set; }

        private TMP_Text NumberText => SerializeFieldNotAssignedException.ThrowIfNull(numberText);

        /// <summary>
        ///     Initializes a new instance of the <see cref="NumberedSnakeBody"/> class.
        /// </summary>
        /// <param name="number">The number assigned to this body part.</param>
        /// <param name="speed">The movement speed of the snake body part.</param>
        /// <param name="followTarget">The target for the snake body part to follow.</param>
        /// <param name="settings">The settings to be used by the snake body part.</param>
        public void Initialize(int number, float speed, Transform followTarget, SnakeSettings settings)
        {
            this.Number = number;
            NumberText.text = number.ToString();
            base.Initialize(speed, followTarget, settings);
        }
    }
}
