namespace PangRemake.WeaponSystem.Bullets
{
    using PangRemake.Constants;
    using UnityEngine;
    using VUDK.Generic.Managers;

    public static class BulletsFactory
    {
        /// <summary>
        /// Creates a <see cref="HarpoonBullet"/>.
        /// </summary>
        /// <returns>Created <see cref="HarpoonBullet"/>.</returns>
        public static HarpoonBullet CreateHarpoonBullet()
        {
            GameManager.Instance.PoolsManager.Pools[Constants.Pools.s_HarpoonsPool].Get().
                TryGetComponent(out HarpoonBullet bullet);
            return bullet;
        }

        /// <summary>
        /// Creates a <see cref="HarpooRifleBulletBullet"/>.
        /// </summary>
        /// <returns>Created <see cref="RifleBullet"/>.</returns>
        public static RifleBullet CreateRifleBullet()
        {
            GameManager.Instance.PoolsManager.Pools[Constants.Pools.s_RifleBulletPool].Get().
                TryGetComponent(out RifleBullet bullet);
            return bullet;
        }
    }
}