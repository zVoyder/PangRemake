namespace PangRemake.Enemies
{
    using UnityEngine;
    using VUDK.Generic.Managers;
    using VUDK.Patterns.ObjectPool;

    public class MediumBalloon : BalloonBase
    {
        public override Pool RelatedPool => GameManager.Instance.PoolsManager.Pools[Constants.Pools.s_MediumBalloonsPool];

        protected override GameObject GenerateBalloon(Vector2 startBounceDirection)
        {
            SmallBalloon balloon = BalloonsConcreteFactory.CreateSmallBalloon(startBounceDirection);
            return balloon.gameObject;
        }
    }
}