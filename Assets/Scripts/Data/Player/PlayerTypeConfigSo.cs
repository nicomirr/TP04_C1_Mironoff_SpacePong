using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "PlayerTypeConfig", menuName = "Scriptable Objects/PlayerTypeConfig")]
    public class PlayerTypeConfigSo : ScriptableObject
    {
        [SerializeField] private PlayerType _player;
        public PlayerType Player => _player;

    }
}


