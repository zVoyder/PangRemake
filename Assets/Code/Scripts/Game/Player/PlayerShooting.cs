namespace PangRemake.Player
{
    using System;
    using UnityEngine;
    using VUDK.Generic.Serializable;
    using VUDK.Generic.WeaponSystem;
    using PangRemake.Managers;

    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField]
        private SerializableDictionary<string, WeaponBase> _weapons;

        [SerializeField]
        private string _defaultWeaponKey;

        public WeaponBase CurrentWeapon { get; private set; }

        public event Action OnGeneralShoot;

        public void Init()
        {
            ChangeWeaponToDefault();
        }

        private void OnEnable()
        {
            InputManager.s_Inputs.Player.Shoot.started += Shoot;
        }

        private void OnDisable()
        {
            InputManager.s_Inputs.Player.Shoot.started -= Shoot;
        }

        public void ChangeWeapon(string weaponKey)
        {
            if (!_weapons[weaponKey])
                return;

            CurrentWeapon = _weapons[weaponKey];
            CurrentWeapon.Init();
        }

        private void ChangeWeaponToDefault()
        {
            ChangeWeapon(_defaultWeaponKey);
        }

        private void Shoot(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (!CurrentWeapon.IsShooting)
            {
                OnGeneralShoot?.Invoke();
            }
            CurrentWeapon.PullTrigger();
        }
    }
}