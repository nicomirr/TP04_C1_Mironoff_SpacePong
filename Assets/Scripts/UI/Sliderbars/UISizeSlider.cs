using Game.Player;

namespace Game.UI.Slidebars
{
    public class UISizeSlider : UISlider
    {
        private float _currentScale;

        protected override void Awake()
        {
            base.Awake();

            _slider.onValueChanged.AddListener(OnScaleChanged);

            UIEvents.OnSizeSliderValueInitialized += InitializeScale;
        }

        private void Start()
        {
            UIEvents.RaiseSizeSliderInitialValueRequested(_playerType);
        }

        private void OnDestroy()
        {
            _slider.onValueChanged.RemoveAllListeners();
            UIEvents.OnSizeSliderValueInitialized -= InitializeScale;
        }

        private void InitializeScale(PlayerType playerType, float scale)
        {
            if (_playerType != playerType) return;

            _currentScale = scale;
            _slider.value = _currentScale;
            UpdateValueText();
        }

        private void OnScaleChanged(float scale)
        {
            PlayerEvents.RaisePlayerSizeChangeRequested(_playerType, scale);
            _currentScale = scale;
            UpdateValueText();
        }

        protected override void UpdateValueText()
        {
            //ARREGLAR!!!!!!!!!!!!!!!!!!!!!!!!!!11111

            if (_currentScale >= 1.6f)
                _valueText.text = "Long";
            else if (_currentScale >= 1.4f)
                _valueText.text = "Medium";
            else
                _valueText.text = "Short";
        }
    }

}
