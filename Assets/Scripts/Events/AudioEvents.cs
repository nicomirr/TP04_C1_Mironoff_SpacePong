using System;

namespace Game.Events
{
    public static class AudioEvents
    {
        public static event Action OnInitializeVolumeRequest;

        public static event Action<float> OnInitializeVolume;

        public static event Action<float> OnVolumeChanged;

        public static event Action<AudioType> OnSFXAudioPlayRequested;

        public static void RaiseInitializeVolumeRequest()
        {
            OnInitializeVolumeRequest?.Invoke();
        }

        public static void RaiseInitializeVolume(float volume)
        {
            OnInitializeVolume?.Invoke(volume);
        }
        
        public static void RaiseVolumeChanged(float volume)
        {
            OnVolumeChanged?.Invoke(volume);
        }

        public static void RaiseSFXAudioPlayRequested(AudioType audioType)
        {
            OnSFXAudioPlayRequested?.Invoke(audioType);
        }

    }

}
