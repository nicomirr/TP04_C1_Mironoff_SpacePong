using Game.Data;
using UnityEngine;

namespace Game.Ball
{
    public class BallDirectionCorrector : MonoBehaviour
    {
        private float _minHorizontalXDirection;
        private float _maxHorizontalXDirection;

        public void Initialize(BallConfigurationSo data)
        {
            _minHorizontalXDirection = data.MinHorizontalXDirection;
            _maxHorizontalXDirection = data.MaxHorizontalXdirection;
        }

        public Vector2 GetAdjustedDirection(Vector2 direction)
        {
            direction = direction.normalized;

            if (Mathf.Abs(direction.x) < _minHorizontalXDirection)
                return AdjustDirection(direction, _minHorizontalXDirection);

            if (Mathf.Abs(direction.x) > _maxHorizontalXDirection)
                return AdjustDirection(direction, _maxHorizontalXDirection);

            return direction;
        }

        private Vector2 AdjustDirection(Vector2 direction, float horizontalDirection)
        {
            float xSign = Mathf.Sign(direction.x);
            float ySign = Mathf.Sign(direction.y);

            direction.x = xSign * horizontalDirection;
            direction.y = ySign * Mathf.Sqrt(1f - horizontalDirection * horizontalDirection);

            return direction;
        }
    }
}

