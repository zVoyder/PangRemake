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

        /// <summary>
        /// Initializes the Physic of the balloon.
        /// </summary>
        /// <param name="bounceDirection">Starting Bounce direction.</param>
        /// <param name="rigidbody">Rigidbody of the balloon.</param>
        public void Init(Vector2 bounceDirection, Rigidbody2D rigidbody)
        {
            BounceDirection = bounceDirection;
            _rb = rigidbody;
            Bounce(BounceDirection, _bounceForce / 2f);
        }

        /// <summary>
        /// Bounces in a direction.
        /// </summary>
        /// <param name="direction">Bounce direction.</param>
        /// <param name="force">Bounce force.</param>
        private void Bounce(Vector2 direction, float force)
        {
            _rb.velocity = Vector2.zero;
            _rb.AddForce(direction * force, ForceMode2D.Impulse);
        }

        /// <summary>
        /// Inverts the horizzontal bounce direction.
        /// </summary>
        private void FlipDirection()
        {
            BounceDirection = new Vector2(-BounceDirection.x, BounceDirection.y);
        }

        /// <summary>
        /// Gets the correct bounce direction based on the height of the collided transform.
        /// </summary>
        /// <param name="other">Collided transform.</param>
        /// <returns>Correct Bounce direction.</returns>
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