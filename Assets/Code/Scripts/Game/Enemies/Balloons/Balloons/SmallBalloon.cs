namespace PangRemake.Enemies
{
    using UnityEngine;
    using VUDK.Generic.Managers;
    using VUDK.Patterns.ObjectPool;

    public class SmallBalloon : BalloonBase
    {
        public override Pool RelatedPool => GameManager.Instance.PoolsManager.Pools[Constants.Pools.s_SmallBalloonsPool];

        protected override GameObject GenerateBalloon(Vector2 startBounceDirection)
        {
            LittleBalloon balloon = BalloonsConcreteFactory.CreateLittleBalloon(startBounceDirection);
            return balloon.gameObject;
        }
    }
}