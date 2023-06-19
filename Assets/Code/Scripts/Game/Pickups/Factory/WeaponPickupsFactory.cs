namespace PangRemake.Pickups
{
    using VUDK.Generic.Managers;
    using UnityEngine;
    using VUDK.Generic.InteractSystem.Pickups;

    public static class WeaponPickupsFactory
    {
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

        public static HarpoonWeaponPickup CreateHarpoon()
        {
            GameManager.Instance.PoolsManager.Pools[Constants.Pools.s_HarpoonPickup].Get()
                .TryGetComponent(out HarpoonWeaponPickup pickup);
            return pickup;
        }

        public static RifleWeaponPickup CreateRifle()
        {
            GameManager.Instance.PoolsManager.Pools[Constants.Pools.s_RiflePickup].Get()
                .TryGetComponent(out RifleWeaponPickup pickup);
            return pickup;
        }
    }
}