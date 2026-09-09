using UnityEngine;
using UnityEngine.UI;
using Game.Player;
using Game.UI.Slidebars;

namespace Game.UI
{
    public class UIPaddleColor : MonoBehaviour
    {
        //Esto que se decida luego en cada panel de jugador, no en cada slider individual
        [SerializeField] protected PlayerType _playerType;

        [SerializeField] private UIColorSlider _redChannelSlider;
        [SerializeField] private UIColorSlider _greenChannelSlider;
        [SerializeField] private UIColorSlider _blueChannelSlider;

        private Color32 _currentColor;
        private Image _image;


        private void Awake()
        {
            _image = GetComponent<Image>();

            UIEvents.OnColorValueInitialized += InitializeChannel;
            PlayerEvents.OnPlayerColorRandomized += UpdateColorAndChannels;


            _redChannelSlider.OnChannelChanged += ChangeRedChannel;
            _greenChannelSlider.OnChannelChanged += ChangeGreenChannel;
            _blueChannelSlider.OnChannelChanged += ChangeBlueChannel;
        }

        private void Start()
        {
            UIEvents.RaiseColorInitialValueRequested(_playerType);
        }

        private void OnDestroy()
        {
            UIEvents.OnColorValueInitialized -= InitializeChannel;
            PlayerEvents.OnPlayerColorRandomized -= UpdateColorAndChannels;

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
            if (_playerType != playerType) return;

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
            PlayerEvents.RaisePlayerColorChangeRequested(_playerType, color);
        }


    }
}


