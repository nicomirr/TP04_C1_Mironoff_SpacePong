using System;

public static class AudioEvents
{
    public static event Action<AudioType> OnSFXAudioPlayRequested;

    public static void RaiseSFXAudioPlayRequested(AudioType audioType)
    {
        OnSFXAudioPlayRequested?.Invoke(audioType);
    }
    
}
