using UnityEngine;
using System.Collections;

namespace Game.Player
{
    public class PaddleScaler
    {        
        private float _growthFactor = 1f;
        
        private Transform _paddleImageTransform;

        private float _baseYScale;
        
        private bool _paddleGrowth;
        public bool PaddleGrowth => _paddleGrowth;

        public PaddleScaler(Transform paddleImageTransform)
        {
            _paddleImageTransform = paddleImageTransform;         
            _baseYScale = _paddleImageTransform.localScale.y;
        }
        
        public void ChangeScaleWithSettings(float yScale)
        {
            _baseYScale = yScale;
            ApplyScale();
        }

        public IEnumerator GrowPaddleRoutine(float time, float growthFactor)
        {
            _growthFactor = growthFactor;

            _paddleGrowth = true;
            ApplyScale();

            yield return new WaitForSeconds(time);

            _growthFactor = 1;

            _paddleGrowth = false;
            ApplyScale();
        }

        private void ApplyScale()
        {
            float yScale = _paddleGrowth
                ? _baseYScale * _growthFactor
                : _baseYScale;

            _paddleImageTransform.localScale =
                new Vector3(_paddleImageTransform.localScale.x, yScale);
        }
    }
}

