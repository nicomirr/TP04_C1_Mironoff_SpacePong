using Game.Core;
using System;

namespace Game.Events
{
    public static class MatchEvents
    {
        public static event Action OnRoundStarted;

        public static event Action OnRoundFinished;

        public static event Action<PlayerType> OnSideChanged;

        public static event Action<PlayerType> OnPointScored;

        public static event Action<PlayerType,int> OnScoreChanged;

        public static event Action<PlayerType> OnMatchFinished;
        
        public static void RaiseRoundStarted()
        {
            OnRoundStarted?.Invoke();
        }

        public static void RaiseRoundFinished()
        {
            OnRoundFinished?.Invoke();
        }              

        public static void RaiseSideChanged(PlayerType playerType)
        {
            OnSideChanged?.Invoke(playerType);
        }

        public static void RaisePointScored(PlayerType playerType)
        {
            OnPointScored?.Invoke(playerType);
        }

        public static void RaiseScoreChanged(PlayerType playerType, int score)
        {
            OnScoreChanged?.Invoke(playerType, score);
        }

        public static void RaiseMatchFinished(PlayerType playerType)
        {
            OnMatchFinished?.Invoke(playerType);
        }
    }
}

