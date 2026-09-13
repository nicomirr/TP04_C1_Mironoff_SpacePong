using Game.Core;
using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "ScoreUIConfig", menuName = "Scriptable Objects/ScoreUIConfig")]
    public class ScoreUIConfigSo : ScriptableObject
    {
        [SerializeField] private PlayerType _player;
        public PlayerType Player => _player;

    }
}


