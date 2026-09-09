using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "PowerupDataSo", menuName = "Scriptable Objects/PowerupDataSo")]
    public class TimedPowerupDataSo : ScriptableObject
    {
        [SerializeField] protected float _time;
        public float Time => _time;
    }
}


