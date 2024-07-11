#nullable enable

using MathSnake.Exceptions;
using TMPro;
using UnityEngine;

namespace MathSnake.Player
{
    public class NumberedSnakeBody : SnakeBodyBase
    {
        [SerializeField]
        private TMP_Text? numberText;

        private int number;

        private TMP_Text NumberText => SerializeFieldNotAssignedException.ThrowIfNull(numberText);

        public void Initialize(int number, float speed, Transform nextFollowTarget, SnakeSettings settings)
        {
            this.number = number;
            NumberText.text = number.ToString();
            base.Initialize(speed, nextFollowTarget, settings);
        }
    }
}
