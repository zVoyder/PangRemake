namespace PangRemake.Pickups
{
    using UnityEngine;
    using VUDK.Generic.InteractSystem.Pickups;
    using VUDK.Patterns.ObjectPool.Interfaces;
    using VUDK.Patterns.ObjectPool;
    using PangRemake.Player;

    public class WeaponPickup : PickupBase, IPooledObject
    {
        public Pool RelatedPool { get; private set; }

        protected virtual string WeaponKey { get; private set; }

        public override void Interact(GameObject gameObject)
        {
            if(gameObject.TryGetComponent(out PlayerManager player))
            {
                player.Shooting.ChangeWeapon(WeaponKey);
                Dispose();
            }
        }

        public void AssociatePool(Pool associatedPool)
        {
            RelatedPool = associatedPool;
        }

        public void Dispose()
        {
            RelatedPool.Dispose(gameObject);
        }
    }
}