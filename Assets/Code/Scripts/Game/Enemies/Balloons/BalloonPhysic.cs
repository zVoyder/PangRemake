namespace PangRemake.Enemies
{
    using UnityEngine;

    [RequireComponent(typeof(BalloonBase))]
    public class BalloonPhysic : MonoBehaviour
    {
        [SerializeField]
        private float _bounceForce;

        private Rigidbody2D _rb;
        
        [field: SerializeField]
        public Vector2 BounceDirection { get; private set; }

        public void Init(Vector2 bounceDirection, Rigidbody2D rigidbody)
        {
            BounceDirection = bounceDirection;
            _rb = rigidbody;
            Bounce(BounceDirection, _bounceForce / 2f);
        }

        private void Bounce(Vector2 direction, float force)
        {
            _rb.velocity = Vector2.zero;
            _rb.AddForce(direction * force, ForceMode2D.Impulse);
        }

        private void FlipDirection()
        {
            BounceDirection = new Vector2(-BounceDirection.x, BounceDirection.y);
        }

        private Vector2 GetCollisionBunceDirection(Transform other)
        {
            float height = other.position.y - transform.position.y;

            if (height > 0)
                return new Vector2(BounceDirection.x, -BounceDirection.y);

            return BounceDirection;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == 9)
            {
                FlipDirection();
                Bounce(BounceDirection, _bounceForce / 2f);
                return;
            }

            if (collision.gameObject.layer == 7)
            {
                Bounce(GetCollisionBunceDirection(collision.transform), _bounceForce);
                return;
            }
        }
    }
}