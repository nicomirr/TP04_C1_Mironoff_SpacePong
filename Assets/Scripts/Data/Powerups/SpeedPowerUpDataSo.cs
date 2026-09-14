using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "SpeedPowerUpDataSo", menuName = "Scriptable Objects/SpeedPowerUpDataSo")]
    public class SpeedPowerUpDataSo : ScriptableObject
    {
        [SerializeField] private float _speedIncrease;
        public float SpeedIncrease => _speedIncrease;
    }
}


