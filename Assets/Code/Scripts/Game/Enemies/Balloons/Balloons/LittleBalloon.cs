namespace PangRemake.Enemies
{
    using VUDK.Generic.Managers;
    using PangRemake.Events;
    using VUDK.Patterns.ObjectPool;

    public class LittleBalloon : BalloonBase
    {
        public override Pool RelatedPool => GameManager.Instance.PoolsManager.Pools[Constants.Pools.s_LittleBalloonsPool];

        public override void Death()
        {
            base.Death();
            EventManager.Instance.TriggerEvent(EventKeys.s_OnLittleBalloonPop);
        }

        protected override void GenerateBalloons()
        {
        }
    }
}