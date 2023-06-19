namespace PangRemake.Managers
{
    using UnityEngine;
    using VUDK.Constants;
    using VUDK.Generic.Managers;
    using PangRemake.Events;
    using PangRemake.Enemies;

    public class AudioManager : MonoBehaviour
    {
        [SerializeField, Header("Effects Clips")]
        private AudioClip _balloonPopClip;
        [SerializeField]
        private AudioClip _pickUpClip;

        [SerializeField, Header("Weapons Clips")]
        private AudioClip _harpoonShootClip;
        [SerializeField]
        private AudioClip _rifleShootClip;

        [SerializeField, Header("Gameover Clips")]
        private AudioClip _victoryClip;
        [SerializeField]
        private AudioClip _loseClip;

        [SerializeField, Header("Sources")]
        private AudioSource _musicSource;
        [SerializeField]
        private AudioSource _weaponSource;
        [SerializeField]
        private AudioSource _effectsSource;

        private void OnEnable()
        {
            EventManager.Instance.AddListener<BalloonBase>(EventKeys.s_OnBalloonPop, (balloon) => PlayClip(_balloonPopClip, _effectsSource));
            EventManager.Instance.AddListener(VUDKConstants.EventKeys.s_OnPickup, () => PlayClip(_pickUpClip, _effectsSource));
            EventManager.Instance.AddListener(EventKeys.s_OnHarpoonShoot, () => PlayClip(_harpoonShootClip, _weaponSource));
            EventManager.Instance.AddListener(EventKeys.s_OnRifleShoot, () => PlayClip(_rifleShootClip, _weaponSource));
            EventManager.Instance.AddListener(EventKeys.s_OnLose, () => PlayClip(_loseClip, _musicSource));
            EventManager.Instance.AddListener(EventKeys.s_OnVictory, () => PlayClip(_victoryClip, _musicSource));
        }

        private void OnDisable()
        {
            EventManager.Instance.RemoveListener<BalloonBase>(EventKeys.s_OnBalloonPop, (balloon) => PlayClip(_balloonPopClip, _effectsSource));
            EventManager.Instance.RemoveListener(VUDKConstants.EventKeys.s_OnPickup, () => PlayClip(_pickUpClip, _effectsSource));
            EventManager.Instance.RemoveListener(EventKeys.s_OnHarpoonShoot, () => PlayClip(_harpoonShootClip, _weaponSource));
            EventManager.Instance.RemoveListener(EventKeys.s_OnRifleShoot, () => PlayClip(_rifleShootClip, _weaponSource));
            EventManager.Instance.RemoveListener(EventKeys.s_OnLose, () => PlayClip(_loseClip, _musicSource));
            EventManager.Instance.RemoveListener(EventKeys.s_OnVictory, () => PlayClip(_victoryClip, _musicSource));
        }

        /// <summary>
        /// Plays a clip in an <see cref="AudioSource"/>.
        /// </summary>
        /// <param name="clip"><see cref="AudioClip"/> to play.</param>
        /// <param name="source"><see cref="AudioSource"/> where to play the clip in.</param>
        private void PlayClip(AudioClip clip, AudioSource source)
        {
            source.clip = clip;
            source.Play();
        }
    }
}
