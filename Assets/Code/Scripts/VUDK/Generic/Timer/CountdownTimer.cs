namespace VUDK.Generic.Timer
{
    using System.Collections;
    using UnityEngine;
    using VUDK.Constants;
    using VUDK.Generic.Managers;

    public class CountdownTimer : MonoBehaviour
    {
        public void StartTimer(int time)
        {
            StartCoroutine(CountdownRoutine(time));
        }

        public void StopTimer()
        {
            StopAllCoroutines();
        }

        private IEnumerator CountdownRoutine(int time)
        {
            while (time > 0)
            {
                yield return new WaitForSeconds(1);
                time--;
                EventManager.Instance.TriggerEvent(VUDKConstants.EventKeys.s_OnContdownCount, time);
            }

            EventManager.Instance.TriggerEvent(VUDKConstants.EventKeys.s_OnCoundownTimesUp);
        }
    }
}
