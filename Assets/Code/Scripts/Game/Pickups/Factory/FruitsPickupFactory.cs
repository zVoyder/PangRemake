namespace PangRemake.Pickups
{
    using VUDK.Generic.Managers;
    using PangRemake.Data;

    public static class FruitsPickupFactory
    {
        public static FruitPickup CreateFruit(this FruitData data)
        {
            GameManager.Instance.PoolsManager.Pools[Constants.Pools.s_FruitPickup].Get()
                .TryGetComponent(out FruitPickup fruit);
            fruit.Init(data);
            return fruit;
        }
    }
}