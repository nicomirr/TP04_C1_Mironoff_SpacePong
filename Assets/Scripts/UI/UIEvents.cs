using Game.Player;
using System;
using UnityEngine;

namespace Game.UI
{
    public static class UIEvents
    {
        public static event Action OnSettingsClicked;
        public static event Action OnCreditsClicked;
        public static event Action OnBackClicked;

        public static event Action<PlayerType> OnSpeedSliderInitialValueRequested;
        public static event Action<PlayerType, float> OnSpeedSliderValueInitialized;

        public static event Action<PlayerType> OnColorInitialValueRequested;
        public static event Action<PlayerType, Color32> OnColorValueInitialized;

        public static event Action<PlayerType> OnSizeSliderInitialValueRequested;
        public static event Action<PlayerType, float> OnSizeSliderValueInitialized;

        public static void RaiseSettingsClicked()
        {
            OnSettingsClicked?.Invoke();
        }

        public static void RaiseCreditsClicked()
        {
            OnCreditsClicked?.Invoke();
        }

        public static void RaiseBackClicked()
        {
            OnBackClicked?.Invoke();
        }

        public static void RaiseSpeedSliderInitialValueRequested(PlayerType playerType)
        {
            OnSpeedSliderInitialValueRequested?.Invoke(playerType);
        }

        public static void RaiseSpeedSliderValueInitialized(PlayerType playerType, float speed)
        {
            OnSpeedSliderValueInitialized?.Invoke(playerType, speed);
        }

        public static void RaiseColorInitialValueRequested(PlayerType playerType)
        {
            OnColorInitialValueRequested?.Invoke(playerType);
        }

        public static void RaiseColorValueInitialized(PlayerType playerType, Color32 color)
        {
            OnColorValueInitialized?.Invoke(playerType, color);
        }

        public static void RaiseSizeSliderInitialValueRequested(PlayerType playerType)
        {
            OnSizeSliderInitialValueRequested?.Invoke(playerType);
        }

        public static void RaiseSizeValueInitialized(PlayerType playerType, float size)
        {
            OnSizeSliderValueInitialized?.Invoke(playerType, size);
        }
    }
}

