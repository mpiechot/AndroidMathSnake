#nullable enable

using MathSnake.Exceptions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MathSnake.Player
{
    /// <summary>
    ///     Represents the movement of the snakes head.
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

        /// <summary>
        ///     Initializes a new instance of the <see cref="SnakeHeadMovement"/> class.
        /// </summary>
        /// <param name="snakeHeadInstance">The snakes head transform that should be moved.</param>
        /// <param name="snakeSettingsInstance">The snakes settings to use.</param>
        public void Initialize(Transform snakeHeadInstance, SnakeSettings snakeSettingsInstance)
        {
            snakeHead = snakeHeadInstance;
            snakeSettings = snakeSettingsInstance;
        }

        /// <summary>
        ///     Starts the movement of the snake.
        /// </summary>
        public void StartMovement()
        {
            InputControls.Snake.ChangeDirection.performed += UpdateRotationValue;
            InputControls.Snake.ChangeDirection.canceled += StopRotation;

            currentSpeed = SnakeSettings.InitialSpeed;
            MoveSound.Play();
        }

        /// <summary>
        ///     Increases the speed of the snake.
        /// </summary>
        public void IncreaseSpeed()
        {
            currentSpeed += SnakeSettings.IncreaseSpeedBy;
        }

        /// <summary>
        ///     Stops the movement of the snake.
        /// </summary>
        public void StopMovement()
        {
            currentSpeed = 0;
            MoveSound.Stop();

            InputControls.Snake.ChangeDirection.performed -= UpdateRotationValue;
            InputControls.Snake.ChangeDirection.canceled -= StopRotation;
        }

        private void UpdateRotationValue(InputAction.CallbackContext ctx)
        {
            rotationInputValue = SnakeSettings.IncreaseRotationSpeedBy * ctx.ReadValue<float>();
        }

        private void StopRotation(InputAction.CallbackContext _)
        {
            rotationInputValue = 0f;
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
