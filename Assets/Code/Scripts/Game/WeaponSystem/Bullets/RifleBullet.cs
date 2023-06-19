namespace PangRemake.WeaponSystem.Bullets
{
    using UnityEngine;
    using VUDK.Generic.WeaponSystem.Bullets;

    public class RifleBullet : Bullet
    {
        protected override void MoveBullet()
        {
            Rigidbody.velocity = transform.up * Speed;
        }
    }
}