using UnityEngine;
using UnityEngine.UI;
using Game.Events;

namespace Game.UI
{
    public class UIMainPanel : UIPanel
    {
        [SerializeField] private Button _btnPlay;
        [SerializeField] private Button _btnSettings;
        [SerializeField] private Button _btnCredits;
        [SerializeField] private Button _btnExit;

        protected override void Awake()
        {
            base.Awake();

            _btnPlay.onClick.AddListener(OnPlayClicked);
            _btnSettings.onClick.AddListener(OnSettingsClicked);
            _btnCredits.onClick.AddListener(OnCreditsClicked);
            _btnExit.onClick.AddListener(OnExitClicked);            
        }
               
        private void OnDestroy()
        {
            _btnPlay.onClick.RemoveAllListeners();
            _btnSettings.onClick.RemoveAllListeners();
            _btnCredits.onClick.RemoveAllListeners();
            _btnExit.onClick.RemoveAllListeners();
        }

        protected virtual void OnPlayClicked()
        {
            AudioEvents.RaiseSFXAudioPlayRequested(AudioType.ButtonClick);

            HidePanel();
        }

        private void OnSettingsClicked()
        {
            AudioEvents.RaiseSFXAudioPlayRequested(AudioType.ButtonClick);

            HidePanel();
            UIEvents.RaiseSettingsClicked();
        }

        private void OnCreditsClicked()
        {
            AudioEvents.RaiseSFXAudioPlayRequested(AudioType.ButtonClick);

            HidePanel();
            UIEvents.RaiseCreditsClicked();
        }

        private void OnExitClicked()
        {
            AudioEvents.RaiseSFXAudioPlayRequested(AudioType.ButtonClick);

            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
