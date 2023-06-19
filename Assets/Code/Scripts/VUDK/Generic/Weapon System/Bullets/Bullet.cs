namespace VUDK.Generic.WeaponSystem.Bullets
{
    using System;
    using UnityEngine;
    using VUDK.Generic.EntitySystem.Interfaces;
    using VUDK.Patterns.ObjectPool;
    using VUDK.Patterns.ObjectPool.Interfaces;

    [RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour, IPooledObject
    {
        [Header("Bullet settings")]
        public float Damage = 1f;
        public float Speed = 1f;

        [SerializeField, Header("Dispose")]
        protected float TimeBeforeDispose;

        protected Rigidbody2D Rigidbody;

        public bool IsSetted { get; private set; }

        public Pool RelatedPool { get; private set; }

        public static event Action<Vector3> OnBulletHit;

        /// <summary>
        /// Initializes this <see cref="Bullet"/>.
        /// </summary>
        /// <param name="damage">Bullet damage.</param>
        /// <param name="speed">Bullet speed.</param>
        public virtual void Init(float damage, float speed)
        {
            Damage = damage;
            Speed = speed;
            IsSetted = true;
        }

        /// <summary>
        /// Checks if this <see cref="Bullet"/> has been setted.
        /// </summary>
        /// <returns></returns>
        public bool Check()
        {
            return IsSetted;
        }

        protected virtual void Awake()
        {
            TryGetComponent(out Collider2D collider);
            TryGetComponent(out Rigidbody);
            collider.isTrigger = true;
        }

        protected virtual void OnEnable()
        {
            CancelInvoke();
            Invoke("Dispose", TimeBeforeDispose);
        }

        /// <summary>
        /// Starts moving the bullet.
        /// </summary>
        public virtual void ShootBullet()
        {
            MoveBullet();
        }

        /// <summary>
        /// Moves the bullet by its rigidbody velocity.
        /// </summary>
        protected virtual void MoveBullet()
        {
            Rigidbody.velocity = transform.forward * Speed;
        }

        public void AssociatePool(Pool associatedPool)
        {
            RelatedPool = associatedPool;
        }

        public virtual void Dispose()
        {
            RelatedPool.Dispose(gameObject);
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.TryGetComponent(out IVulnerable ent))
                ent.TakeDamage(Damage);

            Dispose();
            OnBulletHit?.Invoke(other.ClosestPoint(transform.position));
        }
    }
}
