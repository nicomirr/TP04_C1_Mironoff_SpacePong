using UnityEngine;
using System.Collections.Generic;
using Game.Spawnables;

namespace Game.Spawner
{
    public class SpawnableObjectSpawner : MonoBehaviour
    {
        [SerializeField] private SpawnableObjectPool _spawnableObjectPool;       
        [SerializeField] private SpawnableObjectCategory _category;        

        private Bounds _spawnerBounds;

        private void Awake()
        {
            _spawnerBounds = GetComponentInChildren<BoxCollider2D>().bounds;
        }       

        public GameObject TrySpawnObject(SpawnableObjectCategory category)
        {
            if (_category != category) return null;

            IReadOnlyList<SpawnableObjectType> availableTypes = _spawnableObjectPool.GetTypes(_category);
                        
            float randomX = Random.Range(_spawnerBounds.min.x, _spawnerBounds.max.x);
            float randomY = Random.Range(_spawnerBounds.min.y, _spawnerBounds.max.y);

            Vector2 spawnPos = new Vector2(randomX, randomY);

            SpawnableObjectType randomType = availableTypes[Random.Range(0, availableTypes.Count)];

            GameObject spawnableObject = _spawnableObjectPool.GetSpawnableObject(randomType);

            if (spawnableObject == null)
            {
                Debug.LogWarning("No hay objecto disponible para spawnear");
                return null;
            }

            spawnableObject.transform.position = spawnPos;
            spawnableObject.SetActive(true);

            return spawnableObject;
        }   
        
        public void ReleaseObject(GameObject spawnableObject)
        {
            _spawnableObjectPool.ReleaseSpawnableObject(spawnableObject);
        }                       
    }
}

