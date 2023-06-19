namespace PangRemake.Pickups
{
    using VUDK.Generic.Managers;
    using PangRemake.Data;

    public static class FruitsPickupFactory
    {
        /// <summary>
        /// Creates a <see cref="FruitPickup"/>.
        /// </summary>
        /// <param name="data"><see cref="FruitData"/> data to initialize the pickup with.</param>
        /// <returns>Created <see cref="FruitPickup"/>.</returns>
        public static FruitPickup CreateFruit(this FruitData data)
        {
            GameManager.Instance.PoolsManager.Pools[Constants.Pools.s_FruitPickup].Get()
                .TryGetComponent(out FruitPickup fruit);
            fruit.Init(data);
            return fruit;
        }
    }
}