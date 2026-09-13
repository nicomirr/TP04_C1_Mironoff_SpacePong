using Game.Core;
using Game.Events;
using System;
using System.Collections.Generic;

namespace Game.Match
{
    public class ScoreManager
    {
        private readonly Dictionary<PlayerType, int> _scores = new();

        private readonly int _pointsToWin;


        public ScoreManager(int pointsToWin)
        {
            _pointsToWin = pointsToWin;

            foreach (PlayerType playerType in Enum.GetValues(typeof(PlayerType)))
            {
                _scores.Add(playerType, 0);
            }
        }

        public bool AddPoint(PlayerType playerType)
        {
            _scores[playerType]++;

            MatchEvents.RaiseScoreChanged(playerType, _scores[playerType]);

            return _scores[playerType] >= _pointsToWin;
        }
    }
}

