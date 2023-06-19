namespace PangRemake.Pickups.Interfaces
{
    using PangRemake.Data;
    using UnityEngine;

    public interface IFruitPickup
    {
        public void Init(FruitData fruit);

        public void ChangeSprite(Sprite sprite);
    }
}