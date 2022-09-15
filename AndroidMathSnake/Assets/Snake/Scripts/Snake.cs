#nullable enable

using System;
using UnityEngine;

namespace MathSnake.Snake
{
    public class Snake : MonoBehaviour
    {
        [Header("Snake Settings")]
        [SerializeField] private SnakeSettings snakeSettings;
        [SerializeField] private SnakeMovement snakeMovement;
        [SerializeField] private SnakeEatment snakeEatment;
        [SerializeField] private AudioSource dieSound;

        //private int currentNums { get; set; }
        
        private void Awake()
        {
            _ = snakeEatment ?? throw new ArgumentNullException(nameof(snakeEatment));
            _ = snakeMovement ?? throw new ArgumentNullException(nameof(snakeMovement));
            _ = snakeSettings ?? throw new ArgumentNullException(nameof(snakeSettings));
        }

        void Start()
        {
            snakeEatment.AppleEatenEvent += SnakeEatment_OnAppleEaten;
            snakeEatment.WallEatenEvent += SnakeEatment_OnWallEaten;

            snakeSettings.CurrentSpeed = snakeSettings.Speed;
            snakeSettings.CurrentRotation = snakeSettings.RotationSpeed;
        }

        private void SnakeEatment_OnWallEaten(object sender, EventArgs e)
        {
            if (dieSound != null)
            {
                dieSound.Play();
            }

            snakeSettings.Speed = 0;
            Debug.Log("Snake hit a Wall");
            //PlayerValues.Score = Int32.Parse(GameMaster.gm.currentScore.text);
            //StartCoroutine(StartUIControll.focusOn());
            //SceneManager.LoadScene("UpdateHighScore");
            Destroy(gameObject);
            Destroy(GameObject.FindGameObjectWithTag("BodyParts"));
        }

        private void SnakeEatment_OnAppleEaten(object sender, int eatenNumber)
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
            Debug.Log($"Snake eat apple with number {eatenNumber}");
            IncreaseSpeed();
        }

        public void IncreaseSpeed()
        {
            snakeSettings.CurrentSpeed += snakeSettings.IncreaseSpeedBy;
            snakeSettings.CurrentRotation += snakeSettings.IncreaseRotationBy;
        }

        private void OnDestroy()
        {
            snakeEatment.AppleEatenEvent -= SnakeEatment_OnAppleEaten;
            snakeEatment.WallEatenEvent -= SnakeEatment_OnWallEaten;
        }
    }
}
