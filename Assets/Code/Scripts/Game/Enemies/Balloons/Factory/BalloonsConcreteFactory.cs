﻿namespace PangRemake.Enemies
{
    using UnityEngine;
    using VUDK.Generic.Managers;

    public static class BalloonsConcreteFactory
    {
        public static BigBalloon CreateBigBalloon(Vector2 bounceDirection)
        {
            GameManager.Instance.PoolsManager.Pools[Constants.Pools.s_BigBalloonsPool].Get()
                .TryGetComponent(out BigBalloon balloon);
            balloon.Init(bounceDirection);
            return balloon;
        }

        public static MediumBalloon CreateMediumBalloon(Vector2 bounceDirection)
        {
            GameManager.Instance.PoolsManager.Pools[Constants.Pools.s_MediumBalloonsPool].Get()
                .TryGetComponent(out MediumBalloon balloon);
            balloon.Init(bounceDirection);
            return balloon;
        }

        public static SmallBalloon CreateSmallBalloon(Vector2 bounceDirection)
        {
            GameManager.Instance.PoolsManager.Pools[Constants.Pools.s_SmallBalloonsPool].Get()
                .TryGetComponent(out SmallBalloon balloon);
            balloon.Init(bounceDirection);
            return balloon;
        }

        public static LittleBalloon CreateLittleBalloon(Vector2 bounceDirection)
        {
            GameManager.Instance.PoolsManager.Pools[Constants.Pools.s_LittleBalloonsPool].Get()
                .TryGetComponent(out LittleBalloon balloon);
            balloon.Init(bounceDirection);
            return balloon;
        }
    }
}