namespace PangRemake.Player
{
    using UnityEngine;

    [RequireComponent(typeof(PlayerGraphicsController))]
    [RequireComponent(typeof(PlayerShooting))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerEntity))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerManager : MonoBehaviour
    {
        public PlayerGraphicsController Graphics { get; private set; }
        public PlayerShooting Shooting { get; private set; }
        public PlayerMovement Movement { get; private set; }
        public PlayerEntity Entity { get; private set; }
        public Rigidbody2D Rigidbody { get; private set; }
        public Collider2D Collider { get; private set; }
        public SpriteRenderer Sprite { get; private set; }
        public Animator Animator { get; private set; }

        private void Awake()
        {
            TryGetComponent(out PlayerGraphicsController graphics);
            TryGetComponent(out PlayerShooting shoot);
            TryGetComponent(out PlayerMovement movement);
            TryGetComponent(out PlayerEntity entity);
            TryGetComponent(out Rigidbody2D rigidbody);
            TryGetComponent(out Collider2D collider);
            TryGetComponent(out SpriteRenderer sprite);
            TryGetComponent(out Animator animator);

            Graphics = graphics;
            Shooting = shoot;
            Movement = movement;
            Entity = entity;
            Rigidbody = rigidbody;
            Collider = collider;
            Sprite = sprite;
            Animator = animator;

            Entity.Init(this);
            Graphics.Init(this);
            Movement.Init(this);
            Shooting.Init();
        }
    }
}