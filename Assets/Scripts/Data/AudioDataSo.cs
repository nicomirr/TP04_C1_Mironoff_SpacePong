using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "AudioDataSo", menuName = "Scriptable Objects/AudioDataSo")]
    public class AudioDataSo : ScriptableObject
    {
        [SerializeField] private AudioType _audioType;
        public AudioType AudioType => _audioType;

        [SerializeField] private AudioClip _audioClip;
        public AudioClip AudioClip => _audioClip;   
    }
}

