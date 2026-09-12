using Game.Core;
using System;

namespace Game.Events
{
    public static class MatchEvents
    {
        public static event Action OnRoundStarted;
        public static event Action OnRoundFinished;
        public static event Action<PlayerType> OnPointScored;
        
        public static void RaiseRoundStarted()
        {
            OnRoundStarted?.Invoke();
        }

        public static void RaiseRoundFinished()
        {
            OnRoundFinished?.Invoke();
        }              

        public static void RaisePointScored(PlayerType playerType)
        {
            OnPointScored?.Invoke(playerType);
        }
    }
}

