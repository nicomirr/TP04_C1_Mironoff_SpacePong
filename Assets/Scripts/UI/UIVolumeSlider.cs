using UnityEngine;
using UnityEngine.UI;
using Game.Events;

public class UIVolumeSlider : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(OnVolumeChanged);

        AudioEvents.OnInitializeVolume += InitializeSliderValue;
    }

    private void Start()
    {
        AudioEvents.RaiseInitializeVolumeRequest();
    }

    private void OnDestroy()
    {
        _slider.onValueChanged.RemoveAllListeners();
        AudioEvents.OnInitializeVolume -= InitializeSliderValue;
    }

    private void InitializeSliderValue(float volume)
    {
        _slider.value = volume;
    }

    private void OnVolumeChanged(float volume)
    {
        AudioEvents.RaiseVolumeChanged(volume);
    }
}
