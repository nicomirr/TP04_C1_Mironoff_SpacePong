using UnityEngine;
using System.Collections.Generic;
using Game.Data;
using Game.Spawnables;


namespace Game.Spawner
{
    public class SpawnableObjectPool : MonoBehaviour
    {
        [SerializeField] private int _similarObjectsAmount = 3;
        [SerializeField] private SpawnableObjectFactory _factory;

        private Dictionary<SpawnableObjectType, List<GameObject>> _pool = new();

        private Dictionary<SpawnableObjectCategory, List<SpawnableObjectType>> _typesByCategory = new();

        private void Awake()
        {
            _factory.Initialize();

            for (int i = 0; i < _factory.Count; i++)
            {
                SpawnableObjectSo data = _factory.GetSpawnableObjectData(i);

                _pool.Add(data.Type, new List<GameObject>());

                if (!_typesByCategory.ContainsKey(data.Category))
                {
                    _typesByCategory.Add(data.Category, new List<SpawnableObjectType>());
                }

                _typesByCategory[data.Category].Add(data.Type);

                for (int j = 0; j < _similarObjectsAmount; j++)
                {
                    GameObject spawnableObject = _factory.CreateSpawnableObject(data.Type);

                    spawnableObject.transform.parent = transform;
                    spawnableObject.SetActive(false);

                    _pool[data.Type].Add(spawnableObject);
                }
            }

        }

        public IReadOnlyList<SpawnableObjectType> GetTypes(SpawnableObjectCategory category)
        {
            return _typesByCategory[category];
        }

        public GameObject GetSpawnableObject(SpawnableObjectType type)
        {
            foreach (GameObject spawnableObject in _pool[type])
            {
                if (!spawnableObject.activeSelf)
                    return spawnableObject;
            }

            return null;
        }

        public void ReleaseSpawnableObject(GameObject spawnableObject)
        {
            spawnableObject.SetActive(false);
        }
                
    }

}
