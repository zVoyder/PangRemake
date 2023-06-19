namespace PangRemake.Pickups
{
    using VUDK.Generic.Managers;
    using UnityEngine;
    using VUDK.Generic.InteractSystem.Pickups;

    public static class WeaponPickupsFactory
    {
        /// <summary>
        /// Creates a random <see cref="WeaponPickup"/>.
        /// </summary>
        /// <returns>Created <see cref="WeaponPickup"/>.</returns>
        public static PickupBase CreateRandomWeaponPickup()
        {
            int randomIndex = Random.Range(0, 2);

            switch (randomIndex)
            {
                case 0:
                    return CreateHarpoon();
                case 1:
                    return CreateRifle();
            }

            return null;
        }

        /// <summary>
        /// Creates a <see cref="HarpoonWeaponPickup"/>.
        /// </summary>
        /// <returns>Created <see cref="HarpoonWeaponPickup"/>.</returns>
        public static HarpoonWeaponPickup CreateHarpoon()
        {
            GameManager.Instance.PoolsManager.Pools[Constants.Pools.s_HarpoonPickup].Get()
                .TryGetComponent(out HarpoonWeaponPickup pickup);
            return pickup;
        }

        /// <summary>
        /// Creates a <see cref="RifleWeaponPickup"/>.
        /// </summary>
        /// <returns>Created <see cref="RifleWeaponPickup"/>.</returns>
        public static RifleWeaponPickup CreateRifle()
        {
            GameManager.Instance.PoolsManager.Pools[Constants.Pools.s_RiflePickup].Get()
                .TryGetComponent(out RifleWeaponPickup pickup);
            return pickup;
        }
    }
}