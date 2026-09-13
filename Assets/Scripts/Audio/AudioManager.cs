using UnityEngine;
using System.Collections.Generic;
using Game.Data;
using Game.Events;


public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _musicAudioSource;
    [SerializeField] private AudioSource _sfxAudioSource;
    
    [SerializeField] private List<AudioDataSo> _audioData = new List<AudioDataSo>();
    private Dictionary<AudioType, AudioClip> _gameAudios;


    private void Awake()
    {
        _gameAudios = new Dictionary<AudioType, AudioClip>();

        foreach(AudioDataSo data in _audioData)
        {
            _gameAudios.Add(data.AudioType, data.AudioClip);
        }
    }

    private void OnEnable()
    {
        AudioEvents.OnVolumeChanged += ChangeVolume;
        AudioEvents.OnSFXAudioPlayRequested += PlaySFXAudio;
    }

    private void OnDisable()
    {
        AudioEvents.OnVolumeChanged -= ChangeVolume;
        AudioEvents.OnSFXAudioPlayRequested -= PlaySFXAudio;
    }

    private void PlaySFXAudio(AudioType audioType)
    {        
        _sfxAudioSource.PlayOneShot(_gameAudios[audioType]);
    }

    private void ChangeVolume(float volume)
    {
        _musicAudioSource.volume = volume;
        _sfxAudioSource.volume = volume;
    }

}
