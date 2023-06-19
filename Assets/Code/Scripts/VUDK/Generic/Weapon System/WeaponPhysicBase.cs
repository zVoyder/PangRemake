namespace VUDK.Generic.WeaponSystem
{
    using PangRemake.Managers;
    using UnityEngine;
    using VUDK.Generic.Managers;
    using VUDK.Generic.WeaponSystem.Bullets;
    using VUDK.Patterns.ObjectPool;
    using VUDK.Patterns.ObjectPool.Interfaces;

    public abstract class WeaponPhysicBase : WeaponBase
    {
        [SerializeField, Header("Bullet")]
        protected float BulletSpeed;
        [SerializeField]
        private bool _alternateBarrel;

        private int _currentBarrelIndex = 0;

        protected override void BulletGeneration()
        {
            base.BulletGeneration();
            if (_alternateBarrel)
            {
                SpawnBullet(BarrelsPoints[_currentBarrelIndex]);
                _currentBarrelIndex = (_currentBarrelIndex + 1) % BarrelsPoints.Length;
            }
            else
            {
                foreach (Transform barrel in BarrelsPoints)
                    SpawnBullet(barrel);
            }
        }

        protected virtual GameObject SpawnBullet(Transform barrel)
        {
            GameObject goBull = CreateBullet();
            goBull.transform.SetPositionAndRotation(barrel.transform.position, barrel.transform.rotation);

            if(goBull.TryGetComponent(out Bullet bull))
            {
                if (!bull.IsSetted)
                    bull.Init(Damage.Random(), BulletSpeed);
                else
                    bull.Damage = Damage.Random();

                bull.ShootBullet();
            }

            return goBull;
        }

        protected virtual GameObject CreateBullet()
        {
            return GameManager.Instance.PoolsManager.Pools["Bullet"].Get();
        }
    }
}