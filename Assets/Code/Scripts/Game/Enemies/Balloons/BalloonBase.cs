namespace PangRemake.Enemies
{
    using UnityEngine;
    using VUDK.Generic.EntitySystem.Interfaces;
    using VUDK.Patterns.ObjectPool;
    using VUDK.Patterns.ObjectPool.Interfaces;
    using VUDK.Generic.Managers;
    using VUDK.Extensions.Transform;
    using PangRemake.Constants;
    using PangRemake.Player;
    using PangRemake.Events;

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(BalloonPhysic))]
    public abstract class BalloonBase : MonoBehaviour, IPooledObject, IVulnerable
    {
        [SerializeField, Header("Balloon")]
        private bool _isBalloonAtStart;
        [SerializeField, Min(0)]
        private int _damage;

        [SerializeField, Header("Balloons Generation")]
        private Transform _balloonSpawnPointOne;
        [SerializeField]
        private Transform _balloonSpawnPointTwo;

        [SerializeField, Header("Score Value")]
        private int _scoreValue;

        private BalloonPhysic _balloonPhysic;

        private Rigidbody2D _rb;
        private Animator _anim;
        private Collider2D _collider;
        private bool _isDead;

        public virtual Pool RelatedPool { get; private set; }

        private void Awake()
        {
            TryGetComponent(out _rb);
            TryGetComponent(out _anim);
            TryGetComponent(out _collider);
            TryGetComponent(out _balloonPhysic);
        }

        protected virtual void Start()
        {
            if(_isBalloonAtStart)
                Init(_balloonPhysic.BounceDirection);
        }

        public virtual void Init(Vector2 bounceDirection)
        {
            _balloonPhysic.Init(bounceDirection, _rb);
        }

        public void AssociatePool(Pool associatedPool)
        {
            RelatedPool = associatedPool;
        }

        public void Dispose()
        {
            _isDead = false;
            _collider.enabled = true;
            _isBalloonAtStart = false;
            _rb.simulated = true;
            RelatedPool.Dispose(gameObject);
        }

        public void TakeDamage(float hitDamage = 1)
        {
            if(!_isDead)
                Death();
        }

        public virtual void Death()
        {
            _isDead = true;
            _collider.enabled = false;
            EventManager.Instance.TriggerEvent(EventKeys.s_OnBalloonPop, this);
            EventManager.Instance.TriggerEvent(EventKeys.s_OnAddScore, _scoreValue);
            GenerateBalloons();
            _rb.simulated = false;
            _anim.SetTrigger(AnimationConstants.s_BalloonExplosion);
        }

        protected virtual void GenerateBalloons()
        {
            Vector2 startDirection = new Vector2(Mathf.Abs(_balloonPhysic.BounceDirection.x), Mathf.Abs(_balloonPhysic.BounceDirection.y));

            GenerateBalloon(startDirection).transform.SetPosition(_balloonSpawnPointOne.position);
            GenerateBalloon(new Vector2(-startDirection.x, startDirection.y)).transform.SetPosition(_balloonSpawnPointTwo.position);
        }

        protected virtual GameObject GenerateBalloon(Vector2 startBounceDirection)
        {
            BalloonBase balloon = BalloonsConcreteFactory.CreateBigBalloon(startBounceDirection);
            return balloon.gameObject;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.transform.TryGetComponent(out PlayerEntity player))
            {
                DamagePlayer(player);
            }
        }

        private void DamagePlayer(PlayerEntity player)
        {
            player.TakeDamage(_damage);
        }
    }
}