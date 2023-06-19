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
        /// Moves the gameObject using its rigidbody velocity.
        /// </summary>
        private void Movement()
        {
            _rb.velocity = new Vector2(direction * _speed, _rb.velocity.y);
        }

        private void StopMove(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            direction = 0;
            OnMovement?.Invoke(direction);
        }

        private void StartMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            direction = (int)context.ReadValue<float>();
            OnMovement?.Invoke(direction);
        }
    }
}