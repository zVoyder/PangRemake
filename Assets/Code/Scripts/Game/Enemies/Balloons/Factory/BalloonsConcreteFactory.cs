namespace PangRemake.Enemies
{
    using UnityEngine;
    using VUDK.Generic.Managers;

    public static class BalloonsConcreteFactory
    {
        /// <summary>
        /// Creates a <see cref="BigBalloon"/>.
        /// </summary>
        /// <param name="bounceDirection">Starting Bounce direction.</param>
        /// <returns>Created <see cref="BigBalloon"/></returns>
        public static BigBalloon CreateBigBalloon(Vector2 bounceDirection)
        {
            GameManager.Instance.PoolsManager.Pools[Constants.Pools.s_BigBalloonsPool].Get()
                .TryGetComponent(out BigBalloon balloon);
            balloon.Init(bounceDirection);
            return balloon;
        }

        /// <summary>
        /// Creates a <see cref="MediumBalloon"/>.
        /// </summary>
        /// <param name="bounceDirection">Starting Bounce direction.</param>
        /// <returns>Created <see cref="MediumBalloon"/></returns>
        public static MediumBalloon CreateMediumBalloon(Vector2 bounceDirection)
        {
            GameManager.Instance.PoolsManager.Pools[Constants.Pools.s_MediumBalloonsPool].Get()
                .TryGetComponent(out MediumBalloon balloon);
            balloon.Init(bounceDirection);
            return balloon;
        }

        /// <summary>
        /// Creates a <see cref="SmallBalloon"/>.
        /// </summary>
        /// <param name="bounceDirection">Starting Bounce direction.</param>
        /// <returns>Created <see cref="SmallBalloon"/></returns>
        public static SmallBalloon CreateSmallBalloon(Vector2 bounceDirection)
        {
            GameManager.Instance.PoolsManager.Pools[Constants.Pools.s_SmallBalloonsPool].Get()
                .TryGetComponent(out SmallBalloon balloon);
            balloon.Init(bounceDirection);
            return balloon;
        }

        /// <summary>
        /// Creates a <see cref="LittleBalloon"/>.
        /// </summary>
        /// <param name="bounceDirection">Starting Bounce direction.</param>
        /// <returns>Created <see cref="LittleBalloon"/></returns>
        public static LittleBalloon CreateLittleBalloon(Vector2 bounceDirection)
        {
            GameManager.Instance.PoolsManager.Pools[Constants.Pools.s_LittleBalloonsPool].Get()
                .TryGetComponent(out LittleBalloon balloon);
            balloon.Init(bounceDirection);
            return balloon;
        }
    }
}