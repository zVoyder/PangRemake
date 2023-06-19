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

        /// <summary>
        /// Initializes this <see cref="PlayerShooting"/>.
        /// </summary>
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

        /// <summary>
        /// Changes Weapon by its key.
        /// </summary>
        /// <param name="weaponKey">Weapon key of the <see cref="WeaponBase"/> to use.</param>
        public void ChangeWeapon(string weaponKey)
        {
            if (!_weapons[weaponKey])
                return;

            CurrentWeapon = _weapons[weaponKey];
            CurrentWeapon.Init();
        }

        /// <summary>
        /// Changes <see cref="WeaponBase"/> with the assigned default one.
        /// </summary>
        private void ChangeWeaponToDefault()
        {
            ChangeWeapon(_defaultWeaponKey);
        }

        /// <summary>
        /// Shoots with the current equipped <see cref="WeaponBase"/>.
        /// </summary>
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