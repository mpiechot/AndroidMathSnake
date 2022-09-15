#nullable enable

using System;
using System.Collections.Generic;
using UnityEngine;

namespace MathSnake.Snake
{
    public class SnakeBodyController : MonoBehaviour
    {
        [SerializeField] private BodyPartMovement bodyPartPrefab;
        [SerializeField] private GameObject PartsParent;
        [SerializeField] private BodyPartMovement tail;
        [SerializeField] private SnakeEatment snakeEatment;

        private List<Transform> bodyParts = new List<Transform>();

        private void Awake()
        {
            _ = snakeEatment ?? throw new ArgumentNullException(nameof(snakeEatment));
        }

        // Start is called before the first frame update
        void Start()
        {
            snakeEatment.AppleEatenEvent += SnakeEatment_OnAppleEaten;

            //Let the tail follow the Snakehead at the start
            tail.target = transform;

            bodyParts.Add(transform);
        }

        private void SnakeEatment_OnAppleEaten(object sender, int eatenNumber)
        {
            AddBodyPart(eatenNumber);
        }

        private void UpdateTailTarget(GameObject newPart)
        {
            tail.target = newPart.transform;
            tail.StartCoroutine(tail.LetTargetMoveFirst());
        }

        private void AddBodyPart(int num)
        {
            GameObject newPart = GetNewBodyPart(num);

            UpdateTailTarget(newPart);

            bodyParts.Add(newPart.transform);
        }

        private GameObject GetNewBodyPart(int num)
        {
            //Spawn the new part on the location of the last bodyPart of the snake
            Transform spawnPos;
            if (bodyParts.Count == 0)
            {
                spawnPos = transform;
            }
            else
            {
                spawnPos = bodyParts[bodyParts.Count - 1];

            }

            BodyPartMovement bpm = Instantiate(bodyPartPrefab, spawnPos.position, spawnPos.rotation);
            bpm.name = "BodyPart Nr." + bodyParts.Count;

                //Print the eaten number on the bodyPart if not 0
                //if (num != 0)
                //{
                //    TextMeshPro mesh = bpm.GetComponentInChildren<TextMeshPro>();
                //    mesh.text = num.ToString();
                //    currentNums += num;
                //}
            bpm.target = spawnPos;
            bpm.transform.position = new Vector3(bpm.transform.position.x, spawnPos.position.y, bpm.transform.position.z);

            bpm.transform.SetParent(PartsParent.transform);

            return bpm.gameObject;
        }

        private void OnDestroy()
        {
            snakeEatment.AppleEatenEvent -= SnakeEatment_OnAppleEaten;
        }
    }
}
