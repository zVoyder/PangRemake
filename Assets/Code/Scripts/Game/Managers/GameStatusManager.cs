namespace PangRemake.Managers
{
    using System.Linq;
    using UnityEngine;
    using VUDK.Constants;
    using VUDK.Generic.Timer;
    using VUDK.Generic.Managers;
    using PangRemake.Enemies;
    using PangRemake.Events;
    using UnityEngine.Events;

    public class GameStatusManager : MonoBehaviour
    {
        [SerializeField, Header("Timer")]
        private int _time;
        [SerializeField]
        private CountdownTimer _timer;

        [SerializeField, Header("Gameover UnityEvents")]
        private UnityEvent _onLose;
        [SerializeField]
        private UnityEvent _onVictory;
        [SerializeField]
        private UnityEvent _onGamefinished;

        private int _numberOfBalloonsToDestroy;

        private void Awake()
        {
            _numberOfBalloonsToDestroy += FindObjectsByType<BigBalloon>(FindObjectsSortMode.None).Count() * 8;
            _numberOfBalloonsToDestroy += FindObjectsByType<MediumBalloon>(FindObjectsSortMode.None).Count() * 4;
            _numberOfBalloonsToDestroy += FindObjectsByType<SmallBalloon>(FindObjectsSortMode.None).Count() * 2;
            _numberOfBalloonsToDestroy += FindObjectsByType<LittleBalloon>(FindObjectsSortMode.None).Count();
        }

        private void Start()
        {
            _timer.StartTimer(_time);
        }

        private void OnEnable()
        {
            EventManager.Instance.AddListener(VUDKConstants.EventKeys.s_OnCoundownTimesUp, LoseCondition);
            EventManager.Instance.AddListener(EventKeys.s_OnLittleBalloonPop, Decrease);
            EventManager.Instance.AddListener(EventKeys.s_OnGameover, LoseCondition);
        }

        private void OnDisable()
        {
            EventManager.Instance.RemoveListener(VUDKConstants.EventKeys.s_OnCoundownTimesUp, LoseCondition);
            EventManager.Instance.RemoveListener(EventKeys.s_OnGameover, LoseCondition);
            EventManager.Instance.RemoveListener(EventKeys.s_OnLittleBalloonPop, Decrease);
        }

        /// <summary>
        /// Decreases the number of <see cref="LittleBalloon"/> to kill to achieve victory.
        /// </summary>
        private void Decrease()
        {
            _numberOfBalloonsToDestroy--;

            if(_numberOfBalloonsToDestroy <= 0)
            {
                WinCondition();
            }
        }

        /// <summary>
        /// Wins the game.
        /// </summary>
        public void WinCondition()
        {
#if DEBUG
            Debug.Log("Victory!");
#endif
            EventManager.Instance.TriggerEvent(EventKeys.s_OnVictory);
            _onVictory?.Invoke();
            GameFinished();
        }

        /// <summary>
        /// Loses the game.
        /// </summary>
        public void LoseCondition()
        {
#if DEBUG
            Debug.Log("Gameover!");
#endif
            EventManager.Instance.TriggerEvent(EventKeys.s_OnLose);
            _onLose?.Invoke();
            GameFinished();
        }

        /// <summary>
        /// Ends the game.
        /// </summary>
        private void GameFinished()
        {
            _onGamefinished?.Invoke();
            InputManager.s_Inputs.Player.Disable();
            _timer.StopTimer();
            EventManager.Instance.TriggerEvent(EventKeys.s_OnGamefinished);
        }
    }
}