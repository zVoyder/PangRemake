namespace PangRemake.Player
{
    using UnityEngine;
    using VUDK.Generic.EntitySystem;
    using VUDK.Generic.Managers;
    using PangRemake.Events;

    public class PlayerEntity : EntityBase
    {
        [SerializeField]
        private float _deathJumpForce;

        private PlayerManager _playerManager;

        public void Init(PlayerManager player)
        {
            _playerManager = player;
        }

        protected override void DeathEffects()
        {
            EventManager.Instance.TriggerEvent(EventKeys.s_OnGameover);
            DeathJump();
            _playerManager.Collider.enabled = false;
        }

        private void DeathJump()
        {
            _playerManager.Rigidbody.AddForce((Vector2.right + Vector2.up) * _deathJumpForce, ForceMode2D.Impulse);
        }
    }
}