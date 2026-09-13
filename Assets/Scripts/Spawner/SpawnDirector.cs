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

        private GameObject _currentSpawnableObject;
                
        private void OnEnable()
        {
            MatchEvents.OnRoundStarted += StartObjectSpawners;
            MatchEvents.OnRoundFinished += StopObjectSpawners;
        }

        private void OnDisable()
        {
            MatchEvents.OnRoundStarted -= StartObjectSpawners;
            MatchEvents.OnRoundFinished -= StopObjectSpawners;
        }

        private void StartObjectSpawners(int _)
        {
            _currentSpawnableObject = null;
            StartCoroutine(SpawnObjectsRoutine());
        }

        private void StopObjectSpawners()
        {
            StopAllCoroutines();
            _currentSpawnableObject?.SetActive(false);
        }

        private IEnumerator SpawnObjectsRoutine()
        {
            SpawnableObjectCategory[] categories = (SpawnableObjectCategory[])System.Enum.GetValues(typeof(SpawnableObjectCategory));

            while (true)
            {
                float spawnTime = Random.Range(_data.MinSpawnTime, _data.MaxSpawnTime);

                yield return new WaitForSeconds(spawnTime);
                
                SpawnableObjectCategory randomCategory = categories[Random.Range(0, categories.Length)];
                                
                SpawnableObjectSpawner currentSpawner = null;

                foreach (SpawnableObjectSpawner spawner in _spawners)
                {
                    _currentSpawnableObject = spawner.TrySpawnObject(randomCategory);

                    if (_currentSpawnableObject != null)
                    {
                        currentSpawner = spawner;
                        break;
                    }
                }

                float despawnTime = Random.Range(_data.MinDespawnTime, _data.MaxDespawnTime);
                yield return new WaitForSeconds(despawnTime);

                currentSpawner?.ReleaseObject(_currentSpawnableObject);        
                _currentSpawnableObject = null;
            }
        }
        
    }
}

