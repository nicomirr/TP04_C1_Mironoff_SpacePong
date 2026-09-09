using System;
using Game.Player;

namespace Game.Gameplay
{
    public static class GameplayEvents
    {
        public static event Action OnRoundStarted;
        public static event Action OnRoundFinished;

        public static event Action<float> OnBallSpeedBoostActivated;
        public static event Action<PlayerType, float> OnDefenseActivated;
        public static event Action<PlayerType, float, float> OnPaddleGrowthActivated;

        public static void RaiseRoundStarted()
        {
            OnRoundStarted?.Invoke();
        }

        public static void RaiseRoundFinished()
        {
            OnRoundFinished?.Invoke();
        }

        public static void RaiseBallSpeedBoostActivated(float speedIncrease)
        {
            OnBallSpeedBoostActivated?.Invoke(speedIncrease);
        }
        
        public static void RaiseDefenseActivated(PlayerType playerType, float time)
        {
            OnDefenseActivated?.Invoke(playerType, time);
        }
        public static void RaisePaddleGrowthActivated(PlayerType playerType, float time, float growthFactor)
        {
            OnPaddleGrowthActivated?.Invoke(playerType, time, growthFactor);
        }

    }
}

