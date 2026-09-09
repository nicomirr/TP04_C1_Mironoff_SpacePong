using Game.Player;
using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "DefenseConfigurationSo", menuName = "Scriptable Objects/DefenseConfigurationSo")]
    public class DefenseConfigurationSo : ScriptableObject
    {
        [SerializeField] private PlayerType _playerType;
        public PlayerType PlayerType => _playerType;

        [SerializeField] private Vector2 _position;
        public Vector2 Position => _position;
    }
}


