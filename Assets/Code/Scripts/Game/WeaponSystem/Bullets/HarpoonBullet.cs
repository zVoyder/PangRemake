namespace PangRemake.WeaponSystem.Bullets
{
    using VUDK.Generic.WeaponSystem.Bullets;
    using VUDK.Patterns.ObjectPool;

    public class HarpoonBullet : Bullet
    {
        private HarpoonWeapon _harpoonWeapon;

        public void Init(float damage, float speed, HarpoonWeapon weapon)
        {
            base.Init(damage, speed);
            _harpoonWeapon = weapon;
        }

        public override void Dispose()
        {
            base.Dispose();
            _harpoonWeapon.ResetCanShoot();
        }

        public override void ShootBullet()
        {
        }

        protected override void OnEnable()
        {
        }
    }
}