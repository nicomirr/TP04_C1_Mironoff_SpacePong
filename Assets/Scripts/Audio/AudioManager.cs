using UnityEngine;
using System.Collections.Generic;
using Game.Data;


public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _sfxAudioSouce;
    
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
        AudioEvents.OnSFXAudioPlayRequested += PlaySFXAudio;
    }

    private void OnDisable()
    {        
        AudioEvents.OnSFXAudioPlayRequested -= PlaySFXAudio;
    }

    private void PlaySFXAudio(AudioType audioType)
    {        
        _sfxAudioSouce.PlayOneShot(_gameAudios[audioType]);
    }

}
