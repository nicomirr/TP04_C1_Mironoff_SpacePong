
using System;

namespace Game.UI.Slidebars
{
    public class UIColorSlider : UISlider
    {
        private byte _currentChannel;

        public event Action<byte> OnChannelChanged;

        protected override void Awake()
        {
            base.Awake();

            _slider.onValueChanged.AddListener(OnColorChanged);            
        }

        private void OnDestroy()
        {
            _slider.onValueChanged.RemoveAllListeners();
        }
                
        private void OnColorChanged(float value)
        {
            _currentChannel = (byte)value;
            UpdateValueText();

            OnChannelChanged?.Invoke(_currentChannel);
        }                

        public void InitializeSlider(byte channel)
        {
            _currentChannel = channel;
            _slider.value = channel;
            UpdateValueText();
        }

        protected override void UpdateValueText()
        {
            _valueText.text = _currentChannel.ToString();
        }
    }
}

