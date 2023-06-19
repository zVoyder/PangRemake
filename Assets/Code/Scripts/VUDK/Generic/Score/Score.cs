namespace VUDK.Generic.Score
{
    using System;
    using UnityEngine;
    using VUDK.Constants;
    using VUDK.Generic.Managers;

    public class Score : MonoBehaviour
    {
        [SerializeField]
        private string _scorePref;

        public int ScoreValue { get; private set; }
        public int HighScore => PlayerPrefs.GetInt(_scorePref);

        private void Start()
        {
            EventManager.Instance.TriggerEvent(VUDKConstants.EventKeys.s_OnScoreChange, ScoreValue);
            EventManager.Instance.TriggerEvent(VUDKConstants.EventKeys.s_OnHighScoreChange, HighScore);
        }

        public void ChangeScore(int scoreToAdd)
        {
            ScoreValue += scoreToAdd;

            if(ScoreValue < 0)
                ScoreValue = 0;

            EventManager.Instance.TriggerEvent(VUDKConstants.EventKeys.s_OnScoreChange, ScoreValue);
            SaveHighScore();
        }

        public void SaveHighScore()
        {
            if (ScoreValue > HighScore)
            {
                PlayerPrefs.SetInt(_scorePref, ScoreValue);
                EventManager.Instance.TriggerEvent(VUDKConstants.EventKeys.s_OnHighScoreChange, HighScore);
            }
        }
    }
}

