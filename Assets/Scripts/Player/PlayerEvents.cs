using System;
using UnityEngine;

namespace Game.Player
{
    public static class PlayerEvents
    {
        public static event Action<PlayerType> OnPlayerInitialized;

        public static event Action<PlayerType, float> OnPlayerMovementSpeedChangeRequested;

        public static event Action<PlayerType, float> OnPlayerMovementSpeedUpdated;

        public static event Action<PlayerType, Color32> OnPlayerColorChangeRequested;

        public static event Action<PlayerType, Color32> OnPlayerColorUpdated;

        public static event Action<PlayerType, Color32> OnPlayerColorRandomized;

        public static event Action<PlayerType, float> OnPlayerSizeChangeRequested;

        public static event Action<PlayerType, float> OnPlayerSizeUpdated;


        public static void RaisePlayerInitialized(PlayerType playerType)
        {
            OnPlayerInitialized?.Invoke(playerType);
        }

        public static void RaisePlayerMovementSpeedChangeRequested(PlayerType playerType, float speed)
        {
            OnPlayerMovementSpeedChangeRequested?.Invoke(playerType, speed);
        }

        public static void RaisePlayerMovementSpeedUpdated(PlayerType playerType, float speed)
        {
            OnPlayerMovementSpeedUpdated?.Invoke(playerType, speed);
        }

        public static void RaisePlayerColorChangeRequested(PlayerType playerType, Color32 color)
        {
            OnPlayerColorChangeRequested?.Invoke(playerType, color);
        }

        public static void RaisePlayerColorUpdated(PlayerType playerType, Color32 color)
        {
            OnPlayerColorUpdated?.Invoke(playerType, color);
        }

        public static void RaisePlayerColorRandomized(PlayerType playerType, Color32 color)
        {
            OnPlayerColorRandomized?.Invoke(playerType, color);
        }

        public static void RaisePlayerSizeChangeRequested(PlayerType playerType, float scale)
        {
            OnPlayerSizeChangeRequested?.Invoke(playerType, scale);
        }

        public static void RaisePlayerSizeUpdated(PlayerType playerType, float scale)
        {
            OnPlayerSizeUpdated?.Invoke(playerType, scale);
        }

    }
}

