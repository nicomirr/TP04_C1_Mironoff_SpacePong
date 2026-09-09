using System;

namespace Game.Pause
{
    public static class PauseEvents
    {
        //Se dispara en GlobalInputs, escucha PauseManager
        public static event Action OnPauseInputPressed;

        
        public static event Action OnGamePausedByInput;


        public static event Action OnGameUnpausedByInput;

        //Se dispara en UIPauseMenu, escucha PauseManager
        public static event Action OnContinueButtonClicked;

        public static void RaisePauseInputPressed()
        {
            OnPauseInputPressed?.Invoke();
        }

        public static void RaiseGamePausedByInput()
        {
            OnGamePausedByInput?.Invoke();
        }

        public static void RaiseGameUnpausedByInput()
        {
            OnGameUnpausedByInput?.Invoke();
        }

        public static void RaiseContinueClicked()
        {
            OnContinueButtonClicked?.Invoke();
        }

    }
}


