namespace PangRemake.Pickups
{
    using UnityEngine;
    using VUDK.Generic.InteractSystem.Pickups;
    using VUDK.Generic.Managers;
    using VUDK.Patterns.ObjectPool;
    using VUDK.Patterns.ObjectPool.Interfaces;
    using PangRemake.Data;
    using PangRemake.Events;
    using PangRemake.Pickups.Interfaces;
    using PangRemake.Player;

    [RequireComponent(typeof(SpriteRenderer))]
    public class FruitPickup : PickupBase, IPooledObject, IFruitPickup
    {
        public Pool RelatedPool { get; private set; }

        private FruitData _data;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            TryGetComponent(out _spriteRenderer);
        }

        public void Init(FruitData fruitData)
        {
            _data = fruitData;
            ChangeSprite(fruitData.Sprite);
        }

        public void ChangeSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }

        public void AssociatePool(Pool associatedPool)
        {
            RelatedPool = associatedPool;
        }

        public void Dispose()
        {
            RelatedPool.Dispose(gameObject);
        }

        public override void Interact(GameObject Interactor)
        {
            if (Interactor.TryGetComponent(out PlayerManager player))
            {
                EventManager.Instance.TriggerEvent(EventKeys.s_OnAddScore, _data.ScoreValue);
                Dispose();
            }
        }
    }
}
