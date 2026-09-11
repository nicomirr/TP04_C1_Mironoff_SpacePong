using UnityEngine;
using System.Collections;

namespace Game.Player
{
    public class PaddleScaler : MonoBehaviour
    {        
        private float _growthFactor = 1f;
        
        private Transform _paddleTransform;

        private float _baseYScale;
        private bool _paddleGrowth;

        public void Initialize()
        {
            _paddleTransform = GetComponentInChildren<PaddleVisualTag>().transform;            
            _baseYScale = _paddleTransform.localScale.y;
        }
        
        public void ChangeScaleWithSettings(float yScale)
        {
            _baseYScale = yScale;
            ApplyScale();
        }

        public void EnablePaddleGrowth(float time, float growthFactor)
        {
            if (_paddleGrowth)
                StopAllCoroutines();

            StartCoroutine(GrowPaddleRoutine(time, growthFactor));
        }

        private IEnumerator GrowPaddleRoutine(float time, float growthFactor)
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

            _paddleTransform.localScale =
                new Vector3(_paddleTransform.localScale.x, yScale);
        }
    }
}

