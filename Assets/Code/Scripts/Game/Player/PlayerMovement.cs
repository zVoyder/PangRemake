namespace PangRemake.Player
{
    using PangRemake.Managers;
    using System;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Header("Statistics")]
        private float _speed = 1;

        private Rigidbody2D _rb;

        private int direction;

        public event Action<int> OnMovement;

        /// <summary>
        /// Initializes this <see cref="PlayerMovement"/>.
        /// </summary>
        /// <param name="player"><see cref="PlayerManager"/> to initialize this Entity with.</param>
        public void Init(PlayerManager player)
        {
            _rb = player.Rigidbody;
        }

        private void OnEnable()
        {
            InputManager.s_Inputs.Player.Movement.performed += StartMove;
            InputManager.s_Inputs.Player.Movement.canceled += StopMove;
            InputManager.s_Inputs.Player.Shoot.started += StopMove;
        }

        private void OnDisable()
        {
            InputManager.s_Inputs.Player.Movement.performed -= StartMove;
            InputManager.s_Inputs.Player.Movement.canceled -= StopMove;
            InputManager.s_Inputs.Player.Shoot.started -= StopMove;
        }

        private void Update()
        {
            Movement();
        }

        /// <summary>
        /// Moves the GameObject using its rigidbody velocity.
        /// </summary>
        private void Movement()
        {
            _rb.velocity = new Vector2(direction * _speed, _rb.velocity.y);
        }

        /// <summary>
        /// Stops the movement.
        /// </summary>
        private void StopMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            direction = 0;
            OnMovement?.Invoke(direction);
        }

        /// <summary>
        /// Starts the movement.
        /// </summary>
        private void StartMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            direction = (int)context.ReadValue<float>();
            OnMovement?.Invoke(direction);
        }
    }
}