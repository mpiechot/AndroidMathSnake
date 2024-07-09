#nullable enable

using MathSnake.Exceptions;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MathSnake.Snake
{
    /// <summary>
    /// Represents the movement of the snakes head.
    /// </summary>
    public class SnakeHeadMovement : MonoBehaviour
    {
        [SerializeField]
        private AudioSource? moveSound;

        private SnakeSettings? snakeSettings;

        private float currentSpeed;

        private float currentRotation;

        private InputControls? inputControls;

        private float rotationInputValue = 0f;

        private SnakeSettings SnakeSettings => NotInitializedException.ThrowIfNull(snakeSettings);

        private AudioSource MoveSound => SerializeFieldNotAssignedException.ThrowIfNull(moveSound);

        private InputControls InputControls => NotInitializedException.ThrowIfNull(inputControls);

        public void Initialize(SnakeSettings snakeSettings)
        {
            inputControls = new InputControls();
        }

        public void StartMovement()
        {
            InputControls.Snake.Move.performed += OnMovePerformed();
            InputControls.Snake.Move.canceled += OnMoveCanceled();

            currentSpeed = SnakeSettings.CurrentSpeed;
            MoveSound.Play();
        }

        private Action<InputAction.CallbackContext> OnMoveCanceled()
        {
            return _ => rotationInputValue = 0f;
        }

        private Action<InputAction.CallbackContext> OnMovePerformed()
        {
            return ctx => rotationInputValue = ctx.ReadValue<float>();
        }

        public void IncreaseSpeed()
        {
            currentSpeed += SnakeSettings.IncreaseSpeedBy;
        }

        public void StopMovement()
        {
            currentSpeed = 0;
            MoveSound.Stop();

            InputControls.Snake.Move.performed -= OnMovePerformed();
            InputControls.Snake.Move.canceled -= OnMoveCanceled();
        }

        private void Update()
        {
            transform.Rotate(Vector3.up * rotationInputValue * currentRotation * Time.deltaTime);
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime, Space.Self);
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
            StopMovement();
        }
    }
}
