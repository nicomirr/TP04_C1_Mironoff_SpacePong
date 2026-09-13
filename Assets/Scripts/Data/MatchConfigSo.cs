using UnityEngine;
using System.Collections.Generic;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "MatchConfigSo", menuName = "Scriptable Objects/MatchConfigSo")]
    public class MatchConfigSo : ScriptableObject
    {
        [SerializeField] private int _roundTime;
        public int RoundTime => _roundTime;

        [SerializeField] private float _timeBetweenRounds;
        public float TimeBetweenRounds => _timeBetweenRounds;

        [SerializeField] private int _pointsToWin;
        public int PointsToWin => _pointsToWin;

        [SerializeField] private float _winningDisplayDelayTime;
        public float WinningDisplayDelayTime => _winningDisplayDelayTime;

        [SerializeField] private float _winningDisplayTime;
        public float WinningDisplayTime => _winningDisplayTime;

        [SerializeField] private SceneToLoadSo _mainMenuScene;
        public SceneToLoadSo MainMenuScene => _mainMenuScene;
    }
}


