namespace VUDK.Generic.WeaponSystem
{
    using System;
    using System.Collections;
    using UnityEngine;
    using VUDK.Generic.Serializable.Mathematics;

    public abstract class WeaponBase : MonoBehaviour
    {
        [Header("Damage")]
        public Range<float> Damage;

        public float FireRate = 0.2f;

        [Header("Ammo")]
        public bool HasInfiniteAmmo = false;

        [SerializeField]
        protected float MaxAmmunition;

        [SerializeField]
        protected float StartingAmmunition;

        [SerializeField]
        protected float AmmunitionCostPerShot;

        [SerializeField, Header("Barrels")]
        protected Transform[] BarrelsPoints;

        protected float CurrentAmmunition;

        public bool IsShooting { get; protected set; }

        protected bool HasAmmo => (CurrentAmmunition - AmmunitionCostPerShot >= 0f) || HasInfiniteAmmo;

        public event Action OnShoot;
        public event Action OnAmmoFinished;

        public virtual void Init()
        {
            CurrentAmmunition = StartingAmmunition;

            if (StartingAmmunition > MaxAmmunition)
            {
                StartingAmmunition = MaxAmmunition;
                CurrentAmmunition = StartingAmmunition;
            }
        }

        public virtual void PullTrigger()
        {
            if (HasAmmo && !IsShooting)
            {
                OnShoot?.Invoke();
                StartCoroutine(ShootingRoutine());
            }
        }

        public virtual void AddAmmunition(float ammoToAdd)
        {
            CurrentAmmunition += ammoToAdd;

            if (CurrentAmmunition > MaxAmmunition)
                CurrentAmmunition = MaxAmmunition;
        }

        protected virtual void BulletGeneration()
        {
        }

        private IEnumerator ShootingRoutine()
        {
            BulletGeneration();
            CurrentAmmunition -= AmmunitionCostPerShot;
            IsShooting = true;
            yield return new WaitForSeconds(FireRate);
            IsShooting = false;

            if (!HasAmmo)
                OnAmmoFinished?.Invoke();
        }

#if DEBUG || UNITY_EDITOR
        [ContextMenu("Debug Shoot")]
        private void DebugShoot()
        {
            PullTrigger();
        }
#endif
    }
}