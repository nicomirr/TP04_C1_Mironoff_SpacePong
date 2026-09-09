using Game.Player.Configuration;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayersInitializer : MonoBehaviour
    {
        [SerializeField] private Transform _playersParent;
        [SerializeField] private PlayerController _playerPrefab;

        [SerializeField] private List<PlayerConfigurationSo> _playerConfiguration = new List<PlayerConfigurationSo>();

        private void Awake()
        {
            foreach (PlayerConfigurationSo playerConfiguration in _playerConfiguration)
            {
                PlayerController player = Instantiate(_playerPrefab, _playersParent);
                player.Initialize(playerConfiguration);
            }
        }
    }
}

