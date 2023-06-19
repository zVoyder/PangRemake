namespace VUDK.UI.Score
{
    using UnityEngine;
    using TMPro;
    using VUDK.Generic.Score;
    using VUDK.Generic.Managers;
    using VUDK.Constants;

    public class ScoreUI : MonoBehaviour
    {
        [SerializeField, Header("Incipits")]
        private string _incipitScore;
        [SerializeField]
        private string _incipitHighScore;

        [SerializeField, Header("Texts")]
        private TMP_Text _scoreText;
        [SerializeField]
        private TMP_Text _highscoreText;

        private void OnEnable()
        {
            EventManager.Instance.AddListener<int>(VUDKConstants.EventKeys.s_OnScoreChange, UpdateScoreText);
            EventManager.Instance.AddListener<int>(VUDKConstants.EventKeys.s_OnHighScoreChange, UpdateHighScoreText);
        }

        private void OnDisable()
        {
            EventManager.Instance.RemoveListener<int>(VUDKConstants.EventKeys.s_OnScoreChange, UpdateScoreText);
            EventManager.Instance.RemoveListener<int>(VUDKConstants.EventKeys.s_OnHighScoreChange, UpdateHighScoreText);
        }

        private void UpdateScoreText(int score)
        {
            _scoreText.text = _incipitScore + score.ToString();
        }

        private void UpdateHighScoreText(int highScore)
        {
            _highscoreText.text = _incipitHighScore + highScore.ToString();
        }
    }
}