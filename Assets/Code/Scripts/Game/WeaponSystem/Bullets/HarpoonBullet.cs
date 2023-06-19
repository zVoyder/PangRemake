namespace PangRemake.WeaponSystem.Bullets
{
    using VUDK.Generic.WeaponSystem.Bullets;
    using VUDK.Patterns.ObjectPool;

    public class HarpoonBullet : Bullet
    {
        private HarpoonWeapon _harpoonWeapon;

        /// <summary>
        /// Initializes this <see cref="HarpoonBullet"/>.
        /// </summary>
        /// <param name="damage">Bullet Damage.</param>
        /// <param name="weapon">Associated <see cref="HarpoonWeapon"/>.</param>
        public void Init(float damage, HarpoonWeapon weapon)
        {
            base.Init(damage, 0);
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