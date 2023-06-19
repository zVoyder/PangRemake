namespace PangRemake.Data
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Pickups/Fruit")]
    public class FruitData : ScriptableObject
    {
        public Sprite Sprite;
        public int ScoreValue;
    }
}