using UnityEngine;
using System.Collections.Generic;
using Game.Data;
using Game.Player;

public class DefenseInitializer : MonoBehaviour
{
    [SerializeField] private Transform _defenseParent;
    [SerializeField] private PlayerDefense _defensePrefab;
    [SerializeField] private List<DefenseConfigurationSo> _defenseConfigs = new List<DefenseConfigurationSo>();

    private void Awake()
    {
        foreach(DefenseConfigurationSo data in _defenseConfigs)
        {
            PlayerDefense defense = Instantiate(_defensePrefab, _defenseParent);
            defense.Initialize(data);
        }
    }
}
