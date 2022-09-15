#nullable enable

using System.Collections;
using UnityEngine;
using TMPro;
using System;

namespace MathSnake.Snake
{
    public class BodyPartMovement : MonoBehaviour
    {
        [SerializeField] private SnakeSettings snakeSettings;

        public Transform target { get; set; }
        public TextMeshPro text { get; set; }

        private Rigidbody rb;

        private void Awake()
        {
            _ = snakeSettings ?? throw new ArgumentNullException(nameof(snakeSettings));
        }

        // Use this for initialization
        void Start()
        {
            StartCoroutine(WaitSomeTime());

            rb = GetComponent<Rigidbody>();
            text = GetComponentInChildren<TextMeshPro>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (target == null)
            {
                //Debug.LogError("Target is null!");
                return;
            }
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance > snakeSettings.PartsDistance)
            {
                // rb.velocity = (target.position - transform.position) * speed * distance;
                transform.Translate(Vector3.forward * snakeSettings.CurrentSpeed * Time.deltaTime, Space.Self);
                transform.LookAt(target);
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }

        IEnumerator WaitSomeTime()
        {
            yield return new WaitForSeconds(1f);

            GetComponent<BoxCollider>().enabled = true;
        }
        public IEnumerator LetTargetMoveFirst()
        {
            yield return new WaitForSeconds(3f);
        }
    }
}
