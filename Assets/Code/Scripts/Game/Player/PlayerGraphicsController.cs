namespace PangRemake.Player
{
    using UnityEngine;
    using PangRemake.Constants;

    public class PlayerGraphicsController : MonoBehaviour
    {
        private Animator _anim;
        private SpriteRenderer _sprite;

        private bool _defaultFlipX;

        private PlayerManager _playerManager;

        public void Init(PlayerManager player)
        {
            _anim = player.Animator;
            _sprite = player.Sprite;
            _playerManager = player;

            _defaultFlipX = _sprite.flipX;
        }

        private void OnEnable()
        {
            _playerManager.Movement.OnMovement += AnimateMovement;
            _playerManager.Shooting.OnGeneralShoot += AnimateShoot;
            _playerManager.Entity.OnDeath += AnimateDeath;
        }

        private void OnDisable()
        {
            _playerManager.Movement.OnMovement -= AnimateMovement;
            _playerManager.Shooting.OnGeneralShoot -= AnimateShoot;
            _playerManager.Entity.OnDeath -= AnimateDeath;
        }

        private void AnimateMovement(int direction)
        {
            Flip(direction);
            _anim.SetFloat(AnimationConstants.s_PlayerMovement, direction);
        }

        private void AnimateShoot()
        {
            _anim.SetTrigger(AnimationConstants.s_PlayerShoot);
        }

        private void AnimateDeath()
        {
            _anim.SetTrigger(Constants.AnimationConstants.s_PlayerDeath);
        }

        private void Flip(int direction)
        {
            if (_defaultFlipX)
                _sprite.flipX = direction < 0;
            else
                _sprite.flipX = direction > 0;
        }
    }
}