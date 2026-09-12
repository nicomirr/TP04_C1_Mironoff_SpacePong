using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Game.Events;
using Game.Spawnables;
using Game.Data;

namespace Game.Spawner
{
    public class SpawnDirector : MonoBehaviour
    {
        [SerializeField] private SpawnerConfigSo _data;
        [SerializeField] private List<SpawnableObjectSpawner> _spawners = new List<SpawnableObjectSpawner>();

        private void Awake()
        {
            MatchEvents.OnRoundStarted += StartSpawnObjectsRoutine;
        }

        private void OnDestroy()
        {
            MatchEvents.OnRoundStarted -= StartSpawnObjectsRoutine;
        }

        private void StartSpawnObjectsRoutine()
        {
            StartCoroutine(SpawnObjectsRoutine());
        }

        private IEnumerator SpawnObjectsRoutine()
        {
            SpawnableObjectCategory[] categories = (SpawnableObjectCategory[])System.Enum.GetValues(typeof(SpawnableObjectCategory));

            while (true)
            {
                float spawnTime = Random.Range(_data.MinSpawnTime, _data.MaxSpawnTime);

                yield return new WaitForSeconds(spawnTime);
                
                SpawnableObjectCategory randomCategory = categories[Random.Range(0, categories.Length)];

                GameObject spawnableObject = null;
                SpawnableObjectSpawner currentSpawner = null;

                foreach (SpawnableObjectSpawner spawner in _spawners)
                {
                    spawnableObject = spawner.TrySpawnObject(randomCategory);

                    if (spawnableObject != null)
                    {
                        currentSpawner = spawner;
                        break;
                    }
                }

                float despawnTime = Random.Range(_data.MinDespawnTime, _data.MaxDespawnTime);
                yield return new WaitForSeconds(despawnTime);

                currentSpawner?.ReleaseObject(spawnableObject);                
            }
        }
    }
}

