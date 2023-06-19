namespace PangRemake.Managers
{
    using VUDK.Generic.Managers;
    using VUDK.Generic.Score;
    using PangRemake.Events;

    public class ScoreManager : Score
    {
        private void OnEnable()
        {
            EventManager.Instance.AddListener<int>(EventKeys.s_OnAddScore, ChangeScore);
        }

        private void OnDisable()
        {
            EventManager.Instance.RemoveListener<int>(EventKeys.s_OnAddScore, ChangeScore);
        }
    }
}