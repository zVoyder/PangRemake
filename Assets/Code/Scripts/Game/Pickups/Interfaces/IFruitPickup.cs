namespace PangRemake.Pickups.Interfaces
{
    using PangRemake.Data;
    using UnityEngine;

    public interface IFruitPickup
    {
        /// <summary>
        /// Initializes a <see cref="IFruitPickup"/>.
        /// </summary>
        /// <param name="fruitData"><see cref="FruitData"/> data to initialize the pickup with.</param>
        public void Init(FruitData fruitData);

        /// <summary>
        /// Changes the sprite.
        /// </summary>
        /// <param name="sprite">New <see cref="Sprite"/>.</param>
        public void ChangeSprite(Sprite sprite);
    }
}