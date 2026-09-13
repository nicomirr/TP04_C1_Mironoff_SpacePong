using System;

namespace Game.Events
{
    public static class BallEvents
    {
        public static event Action OnBallLaunched;

        public static void RaiseBallLaunched()
        {
            OnBallLaunched?.Invoke();
        }
    }
}

