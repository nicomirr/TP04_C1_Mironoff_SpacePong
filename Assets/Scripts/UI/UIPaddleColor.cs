using UnityEngine;
using UnityEngine.UI;
using Game.Core;
using Game.UI.Slidebars;
using Game.Events;
using Game.Data;

namespace Game.UI
{
    public class UIPaddleColor : MonoBehaviour
    {
        [SerializeField] protected PlayerTypeConfigSo _data;

        [SerializeField] private UIColorSlider _redChannelSlider;
        [SerializeField] private UIColorSlider _greenChannelSlider;
        [SerializeField] private UIColorSlider _blueChannelSlider;

        private Color32 _currentColor;
        private Image _image;


        private void Awake()
        {
            _image = GetComponent<Image>();

            UIEvents.OnColorValueInitialized += InitializeChannel;
            PlayerEvents.OnPlayerColorChangedInGameplay += UpdateColorAndChannels;


            _redChannelSlider.OnChannelChanged += ChangeRedChannel;
            _greenChannelSlider.OnChannelChanged += ChangeGreenChannel;
            _blueChannelSlider.OnChannelChanged += ChangeBlueChannel;
        }

        private void Start()
        {
            UIEvents.RaiseColorInitialValueRequested(_data.Player);
        }

        private void OnDestroy()
        {
            UIEvents.OnColorValueInitialized -= InitializeChannel;
            PlayerEvents.OnPlayerColorChangedInGameplay -= UpdateColorAndChannels;

            _redChannelSlider.OnChannelChanged -= ChangeRedChannel;
            _greenChannelSlider.OnChannelChanged -= ChangeGreenChannel;
            _blueChannelSlider.OnChannelChanged -= ChangeBlueChannel;
        }

        private void InitializeChannel(PlayerType playerType, Color32 color)
        {
            UpdateColorAndChannels(playerType, color);
        }

        public void UpdateColorAndChannels(PlayerType playerType, Color32 color)
        {
            if (_data.Player != playerType) return;

            UpdateColor(color);

            _redChannelSlider.InitializeSlider(_currentColor.r);
            _greenChannelSlider.InitializeSlider(_currentColor.g);
            _blueChannelSlider.InitializeSlider(_currentColor.b);
        }

        private void ChangeRedChannel(byte value)
        {
            Color32 color = new Color32(value, _currentColor.g, _currentColor.b, 255);
            UpdateColor(color);
        }

        private void ChangeGreenChannel(byte value)
        {
            Color32 color = new Color32(_currentColor.r, value, _currentColor.b, 255);
            UpdateColor(color);
        }

        private void ChangeBlueChannel(byte value)
        {
            Color32 color = new Color32(_currentColor.r, _currentColor.g, value, 255);
            UpdateColor(color);
        }

        private void UpdateColor(Color32 color)
        {
            _currentColor = color;
            _image.color = _currentColor;
            PlayerEvents.RaisePlayerColorChangeRequested(_data.Player, color);
        }


    }
}


