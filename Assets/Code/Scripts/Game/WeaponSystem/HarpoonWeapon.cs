namespace PangRemake.WeaponSystem
{
    using PangRemake.Events;
    using PangRemake.WeaponSystem.Bullets;
    using UnityEngine;
    using VUDK.Generic.Managers;
    using VUDK.Generic.WeaponSystem;

    public class HarpoonWeapon : WeaponPhysicBase
    {
        public override void Init()
        {
            base.Init();
            HasInfiniteAmmo = true;
        }

        protected override GameObject SpawnBullet(Transform barrel)
        {
            GameObject goBull = CreateBullet();

            if (!goBull)
                return null;

            goBull.transform.SetPositionAndRotation(transform.position, barrel.transform.rotation);

            if (goBull.TryGetComponent(out HarpoonBullet bull))
            {
                if (!bull.IsSetted)
                    bull.Init(Damage.Random(), this);
                else
                    bull.Damage = Damage.Random();
            }

            return goBull;
        }

        /// <summary>
        /// Sets the possibility to shoot to true.
        /// </summary>
        public void ResetCanShoot()
        {
            StopAllCoroutines();
            IsShooting = false;
        }

        protected override GameObject CreateBullet()
        {
            EventManager.Instance.TriggerEvent(EventKeys.s_OnHarpoonShoot);
            return GameManager.Instance.PoolsManager.Pools[Constants.Pools.s_HarpoonsPool].Get();
        }
    }
}