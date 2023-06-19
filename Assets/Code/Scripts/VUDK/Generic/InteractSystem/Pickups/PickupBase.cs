namespace VUDK.Generic.InteractSystem.Pickups
{
    using UnityEngine;
    using VUDK.Constants;
    using VUDK.Generic.Managers;

    public abstract class PickupBase : InteractBase, IPickup
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            EventManager.Instance.TriggerEvent(VUDKConstants.EventKeys.s_OnPickup);
            Interact(other.gameObject);
        }

        public override void Interact(GameObject Interactor)
        {
        }
    }
}
