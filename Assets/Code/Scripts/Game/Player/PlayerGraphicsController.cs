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

        /// <summary>
        /// Initializes the graphics of the player.
        /// </summary>
        /// <param name="player"><see cref="PlayerManager"/> to initialize this Entity with.</param>
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

        /// <summary>
        /// Aimates the movement with a direction.
        /// </summary>
        /// <param name="direction">Direction of the movement.</param>
        private void AnimateMovement(int direction)
        {
            Flip(direction);
            _anim.SetFloat(AnimationConstants.s_PlayerMovement, direction);
        }

        /// <summary>
        /// Animates the shoot.
        /// </summary>
        private void AnimateShoot()
        {
            _anim.SetTrigger(AnimationConstants.s_PlayerShoot);
        }

        /// <summary>
        /// Animates the death.
        /// </summary>
        private void AnimateDeath()
        {
            _anim.SetTrigger(Constants.AnimationConstants.s_PlayerDeath);
        }

        /// <summary>
        /// Flips the sprite X.
        /// </summary>
        /// <param name="direction">Facing direction.</param>
        private void Flip(int direction)
        {
            if (_defaultFlipX)
                _sprite.flipX = direction < 0;
            else
                _sprite.flipX = direction > 0;
        }
    }
}