#nullable enable

using System;
using System.Collections.Generic;
using UnityEngine;

namespace MathSnake.Snake
{
    /// <summary>
    /// Represents a controller for the snakes body for adding and removing new parts.
    /// </summary>
    public class SnakeBodyController : MonoBehaviour
    {
        [SerializeField] private SnakeBodyMovement bodyPartPrefab;
        [SerializeField] private GameObject PartsParent;
        [SerializeField] private SnakeBodyMovement tail;
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
            CreateBodyPart(eatenNumber);
        }

        private void CreateBodyPart(int num)
        {
            //Spawn the new part on the location of the last bodyPart of the snake
            Transform targetTransform;
            if (bodyParts.Count == 0)
            {
                targetTransform = transform;
            }
            else
            {
                targetTransform = bodyParts[bodyParts.Count - 1];

            }

            SnakeBodyMovement bodyPart = Instantiate(bodyPartPrefab, targetTransform.position, targetTransform.rotation);
            bodyPart.name = "BodyPart Nr." + bodyParts.Count;
            bodyPart.target = targetTransform;
            bodyPart.transform.position = new Vector3(bodyPart.transform.position.x, targetTransform.position.y, bodyPart.transform.position.z);
            bodyPart.transform.SetParent(PartsParent.transform);

            //Print the eaten number on the bodyPart if not 0
            //if (num != 0)
            //{
            //    TextMeshPro mesh = bpm.GetComponentInChildren<TextMeshPro>();
            //    mesh.text = num.ToString();
            //    currentNums += num;
            //}

            // Update tail target
            tail.target = bodyPart.transform;

            bodyParts.Add(bodyPart.transform);
        }

        private void OnDestroy()
        {
            snakeEatment.AppleEatenEvent -= SnakeEatment_OnAppleEaten;
        }
    }
}
