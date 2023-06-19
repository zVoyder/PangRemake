namespace PangRemake.WeaponSystem
{
    using UnityEngine;
    using VUDK.Generic.Managers;
    using VUDK.Generic.WeaponSystem;
    using PangRemake.Events;

    public class RifleWeapon : WeaponPhysicBase
    {
        protected override GameObject CreateBullet()
        {
            EventManager.Instance.TriggerEvent(EventKeys.s_OnRifleShoot);
            return GameManager.Instance.PoolsManager.Pools[Constants.Pools.s_RifleBulletPool].Get();
        }
    }
}