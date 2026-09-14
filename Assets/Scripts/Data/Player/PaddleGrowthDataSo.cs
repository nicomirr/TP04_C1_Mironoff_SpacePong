using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "PaddleGrowthDataSo", menuName = "Scriptable Objects/PaddleGrowthDataSo")]
    public class PaddleGrowthDataSo : TimedPowerupDataSo
    {
        [SerializeField] private float _growthFactor;
        public float GrowthFactor => _growthFactor;
    }
}

