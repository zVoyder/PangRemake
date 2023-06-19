namespace PangRemake.Enemies
{
    using UnityEngine;
    using VUDK.Generic.Managers;
    using VUDK.Patterns.ObjectPool;

    public class BigBalloon : BalloonBase
    {
        public override Pool RelatedPool => GameManager.Instance.PoolsManager.Pools[Constants.Pools.s_BigBalloonsPool];

        protected override GameObject GenerateBalloon(Vector2 startBounceDirection)
        {
            MediumBalloon balloon = BalloonsConcreteFactory.CreateMediumBalloon(startBounceDirection);
            return balloon.gameObject;
        }
    }
}