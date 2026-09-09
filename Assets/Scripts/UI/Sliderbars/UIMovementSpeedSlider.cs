using Game.Player;

namespace Game.UI.Slidebars
{
    public class UIMovementSpeedSlider : UISlider
    {           
        private float _currentSpeed;      

        protected override void Awake()
        {
            base.Awake();
            
            _slider.onValueChanged.AddListener(OnSpeedChanged);
            
            UIEvents.OnSpeedSliderValueInitialized += InitializeSpeed;
        }

        private void Start()
        {
            UIEvents.RaiseSpeedSliderInitialValueRequested(_playerType);            
        }

        private void OnDestroy()
        {                      
            //podria estar en base
            _slider.onValueChanged.RemoveAllListeners();
            UIEvents.OnSpeedSliderValueInitialized -= InitializeSpeed;
        }

        private void InitializeSpeed(PlayerType playerType, float speed)
        {
            if (_playerType != playerType) return;

            _currentSpeed = speed;
            _slider.value = _currentSpeed;
            UpdateValueText();
        }       
        
        private void OnSpeedChanged(float speed)
        {
            PlayerEvents.RaisePlayerMovementSpeedChangeRequested(_playerType, speed);
            _currentSpeed = speed;
            UpdateValueText();
        }

        protected override void UpdateValueText()
        {
            int speedPercentage = (int)(_currentSpeed / _slider.maxValue * 100);
            _valueText.text = speedPercentage.ToString() + " %";
        }

    }
}

