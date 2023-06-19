namespace PangRemake.Managers
{
    using System.Collections.Generic;
    using UnityEngine;
    using VUDK.Extensions.Transform;
    using VUDK.Generic.Managers;
    using PangRemake.Enemies;
    using PangRemake.Pickups;
    using PangRemake.Data;
    using PangRemake.Events;

    public class DropsManager : MonoBehaviour
    {
        [SerializeField, Header("Fruit Drops")]
        private List<FruitData> _possibleFruits;
        [SerializeField]
        private List<Transform> _fruitDropPositions;
        [SerializeField]
        private float _fruitDropChance;
        [SerializeField]
        private float _fruitDropRate;

        [SerializeField, Header("Weapon Drops")]
        private float _weaponDropChance;

        private void OnEnable()
        {
            EventManager.Instance.AddListener(EventKeys.s_OnGamefinished, StopDrop);
            EventManager.Instance.AddListener<BalloonBase>(EventKeys.s_OnBalloonPop, DropWeapon);
            InvokeRepeating("DropFruit", _fruitDropRate, _fruitDropRate);
        }

        private void OnDisable()
        {
            EventManager.Instance.RemoveListener(EventKeys.s_OnGamefinished, StopDrop);
            EventManager.Instance.RemoveListener<BalloonBase>(EventKeys.s_OnBalloonPop, DropWeapon);
            StopDrop();
        }

        /// <summary>
        /// Drops a <see cref="WeaponPickup"/> on a <see cref="BalloonBase"/>.
        /// </summary>
        /// <param name="balloon"><see cref="BalloonBase"/> where to drop the weapon.</param>
        private void DropWeapon(BalloonBase balloon)
        {
            if(_weaponDropChance >= Random.Range(0, 101))
                WeaponPickupsFactory.CreateRandomWeaponPickup().transform.SetPosition(balloon.transform.position);
        }

        /// <summary>
        /// Drops a <see cref="FruitPickup"/> in a random position.
        /// </summary>
        private void DropFruit()
        {
            if (_fruitDropChance > Random.Range(0, 101))
            {
                Transform transPos = _fruitDropPositions[Random.Range(0, _fruitDropPositions.Count)];
                FruitData fruitData = _possibleFruits[Random.Range(0, _possibleFruits.Count)];
                fruitData.CreateFruit().transform.SetPosition(transPos.position);
            }
        }

        /// <summary>
        /// Stops the <see cref="FruitPickup"/> drops.
        /// </summary>
        private void StopDrop()
        {
            CancelInvoke();
        }
    }
}