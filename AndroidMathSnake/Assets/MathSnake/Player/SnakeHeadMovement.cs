#nullable enable

using MathSnake.Exceptions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MathSnake.Player
{
    /// <summary>
    /// Represents the movement of the snakes head.
    /// </summary>
    public class SnakeHeadMovement : MonoBehaviour
    {
        [SerializeField]
        private AudioSource? moveSound;

        private Transform? snakeHead;

        private SnakeSettings? snakeSettings;

        private float currentSpeed;

        private float currentRotation;

        private InputControls? inputControls;

        private float rotationInputValue = 0f;

        public float CurrentSpeed => currentSpeed;

        private Transform SnakeHead => NotInitializedException.ThrowIfNull(snakeHead);

        private SnakeSettings SnakeSettings => NotInitializedException.ThrowIfNull(snakeSettings);

        private AudioSource MoveSound => SerializeFieldNotAssignedException.ThrowIfNull(moveSound);

        private InputControls InputControls => NotInitializedException.ThrowIfNull(inputControls);

        private void Awake()
        {
            inputControls = new InputControls();
        }

        public void Initialize(Transform snakeHeadInstance, SnakeSettings snakeSettingsInstance)
        {
            snakeHead = snakeHeadInstance;
            snakeSettings = snakeSettingsInstance;
        }

        public void StartMovement()
        {
            InputControls.Snake.ChangeDirection.performed += UpdateRotationValue;
            InputControls.Snake.ChangeDirection.canceled += StopRotation;

            currentSpeed = SnakeSettings.InitialSpeed;
            MoveSound.Play();
        }

        private void UpdateRotationValue(InputAction.CallbackContext ctx)
        {
            rotationInputValue = SnakeSettings.IncreaseRotationBy * ctx.ReadValue<float>();
        }

        private void StopRotation(InputAction.CallbackContext _)
        {
            rotationInputValue = 0f;
        }

        public void IncreaseSpeed()
        {
            currentSpeed += SnakeSettings.IncreaseSpeedBy;
        }

        public void StopMovement()
        {
            currentSpeed = 0;
            MoveSound.Stop();

            InputControls.Snake.ChangeDirection.performed -= UpdateRotationValue;
            InputControls.Snake.ChangeDirection.canceled -= StopRotation;
        }

        private void Update()
        {
            SnakeHead.Rotate(Vector3.up * rotationInputValue * Time.deltaTime);
            SnakeHead.Translate(Vector3.forward * currentSpeed * Time.deltaTime, Space.Self);
        }

        private void OnEnable()
        {
            InputControls.Enable();
        }

        private void OnDisable()
        {
            InputControls.Disable();
        }

        private void OnDestroy()
        {
            StopMovement();
        }
    }
}
