#nullable enable

using MathSnake.Exceptions;
using TMPro;
using UnityEngine;

namespace MathSnake.Ui
{
    public class UiController : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text? scoreLabel;

        [SerializeField]
        private TMP_Text? searchNumberLabel;

        private TMP_Text ScoreLabel => SerializeFieldNotAssignedException.ThrowIfNull(scoreLabel);

        private TMP_Text SearchNumberLabel => SerializeFieldNotAssignedException.ThrowIfNull(searchNumberLabel);

        public void UpdateScore(int score)
        {
            ScoreLabel.text = score.ToString();
        }

        public void UpdateSearchNumber(int searchNumber)
        {
            SearchNumberLabel.text = searchNumber.ToString();
        }

        public void ShowGameOver()
        {
            // TODO: Implement game over screen
        }
    }
}
