#nullable enable

using System;
using UnityEngine;

namespace MathSnake.Snake
{
    public class SnakeMovement : MonoBehaviour
    {
        [SerializeField] private SnakeSettings snakeSettings;
        [SerializeField] private AudioSource moveSound;

        private InputControls? inputControls;
        private float rotationValue = 0f;

        private void Awake()
        {
            _ = snakeSettings ?? throw new ArgumentNullException(nameof(snakeSettings));

            inputControls = new InputControls();
            inputControls.Snake.Move.performed += ctx => rotationValue = ctx.ReadValue<float>();
            inputControls.Snake.Move.canceled += _ => rotationValue = 0f;
        }

        private void Start()
        {
            if (moveSound != null)
            {
                moveSound.Play();
            }
        }

        private void Update()
        {
            transform.Rotate(Vector3.up * rotationValue * snakeSettings.CurrentRotation * Time.deltaTime);
            transform.Translate(Vector3.forward * snakeSettings.CurrentSpeed * Time.deltaTime, Space.Self);
        }

        private void OnEnable()
        {
            inputControls?.Enable();
        }

        private void OnDisable()
        {
            inputControls?.Disable();
        }

        private void OnDestroy()
        {
            if (moveSound != null)
            {
                moveSound.Stop();
            }
        }
    }
}
