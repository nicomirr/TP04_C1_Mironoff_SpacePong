using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "SpawnerConfig", menuName = "Scriptable Objects/SpawnerConfig")]
    public class SpawnerConfigSo : ScriptableObject
    {
        [SerializeField] private float _minSpawnTime;
        public float MinSpawnTime => _minSpawnTime;

        [SerializeField] private float _maxSpawnTime;
        public float MaxSpawnTime => _maxSpawnTime;

        [SerializeField] private float _minDespawnTime;
        public float MinDespawnTime => _minDespawnTime;

        [SerializeField] private float _maxDespawnTime;
        public float MaxDespawnTime => _maxDespawnTime;
    }
}


