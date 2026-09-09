using UnityEngine;

namespace Game.Player.Configuration
{
    [CreateAssetMenu(fileName = "PlayerConfigurationSo", menuName = "Scriptable Objects/PlayerConfigurationSo")]
    public class PlayerConfigurationSo : ScriptableObject
    {
        [SerializeField] private PlayerType _playerType;
        public PlayerType PlayerType => _playerType;

        [SerializeField] private float _rotation;
        public float Rotation => _rotation;

        [SerializeField] private Vector2 _position;
        public Vector2 Position => _position;
    }
}


