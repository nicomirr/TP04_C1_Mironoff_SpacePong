using UnityEngine;
using System.Collections.Generic;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "MatchConfigSo", menuName = "Scriptable Objects/MatchConfigSo")]
    public class MatchConfigSo : ScriptableObject
    {
        [SerializeField] private int _timeBetweenRounds;
        public int TimeBetweenRounds => _timeBetweenRounds;

        [SerializeField] private int _pointsToWin;
        public int PointsToWin => _pointsToWin;
    }
}


