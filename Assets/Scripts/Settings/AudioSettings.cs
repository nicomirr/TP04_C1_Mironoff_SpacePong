using UnityEngine;
using Game.Events;

namespace Game.Settings
{
    public class AudioSettings : MonoBehaviour
    {
        private static AudioSettings _instance;

        private float _volume = 1.0f;

        private void Awake()
        {

            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
                return;
            }

            AudioEvents.OnInitializeVolumeRequest += InitializeVolume;
            AudioEvents.OnVolumeChanged += ChangeVolume;
        }

        private void OnDestroy()
        {
            AudioEvents.OnInitializeVolumeRequest -= InitializeVolume;
            AudioEvents.OnVolumeChanged -= ChangeVolume;
        }

        private void InitializeVolume()
        {
            AudioEvents.RaiseInitializeVolume(_volume);
        }

        private void ChangeVolume(float volume)
        {
            _volume = volume;
        }
    }
}


