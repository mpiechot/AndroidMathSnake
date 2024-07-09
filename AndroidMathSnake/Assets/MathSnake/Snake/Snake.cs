#nullable enable

using MathSnake.Eatables;
using MathSnake.Exceptions;
using UnityEngine;

namespace MathSnake.Snake
{
    /// <summary>
    ///     Represents a snake in the game.
    /// </summary>
    [RequireComponent(typeof(SnakeHeadMovement))]
    [RequireComponent(typeof(SnakeMouth))]
    public class Snake : MonoBehaviour
    {
        [SerializeField]
        private SnakeHeadMovement? snakeMovement;

        [SerializeField]
        private SnakeMouth? snakeMouth;

        [SerializeField]
        private AudioSource? dieSound;

        private SnakeHeadMovement SnakeMovement => SerializeFieldNotAssignedException.ThrowIfNull(snakeMovement);

        private SnakeMouth SnakeMouth => SerializeFieldNotAssignedException.ThrowIfNull(snakeMouth);

        private AudioSource DieSound => SerializeFieldNotAssignedException.ThrowIfNull(dieSound);

        //private int currentNums { get; set; }


        public void Initialize(GameContext context)
        {
            SnakeMouth.Eaten += OnEatenTriggered;

            SnakeMovement.Initialize(context.SnakeSettings);
            SnakeMovement.StartMovement();
        }

        private void OnEatenTriggered(object sender, EatenEventArgs args)
        {
            if (args.EatenItem.IsGameOver)
            {
                DieSound.Play();
                SnakeMovement.StopMovement();
                Debug.Log("Snake hit a Wall");
                //PlayerValues.Score = Int32.Parse(GameMaster.gm.currentScore.text);
                //StartCoroutine(StartUIControll.focusOn());
                //SceneManager.LoadScene("UpdateHighScore");
                Destroy(gameObject);
                Destroy(GameObject.FindGameObjectWithTag("BodyParts"));
                return;
            }

            if (args.EatenItem is Apple apple)
            {
                //TextMeshProUGUI search = gm.searchNumberField;
                //if (search.text[search.text.Length - 2] == '=')
                //{
                //    search.text += apple.num;
                //}
                //else
                //{
                //    search.text += " + " + apple.num;
                //}
                //gm.searchNumberField.text += "";
                Debug.Log($"Snake eat apple with number {apple.Number}");
                IncreaseSpeed();
            }
        }

        public void IncreaseSpeed()
        {
            SnakeMovement.IncreaseSpeed();
        }

        private void OnDestroy()
        {
            SnakeMouth.Eaten -= OnEatenTriggered;
        }
    }
}
