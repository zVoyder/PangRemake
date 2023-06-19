namespace VUDK.UI.Timer
{
    using VUDK.Generic.Timer;
    using UnityEngine;
    using TMPro;
    using VUDK.Generic.Managers;
    using VUDK.Constants;
    using PangRemake.Managers;

    public class TimerText : MonoBehaviour
    {
        [SerializeField]
        private string _incipit;

        [SerializeField]
        private TMP_Text _text;

        private void OnEnable()
        {
            EventManager.Instance.AddListener<int>(VUDKConstants.EventKeys.s_OnContdownCount, UpdateTimerText);
        }

        private void OnDisable()
        {
            EventManager.Instance.RemoveListener<int>(VUDKConstants.EventKeys.s_OnContdownCount, UpdateTimerText);
        }

        private void UpdateTimerText(int time)
        {
            _text.text = _incipit + time.ToString();
        }
    }
}