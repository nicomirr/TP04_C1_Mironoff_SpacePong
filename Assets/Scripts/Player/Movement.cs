using UnityEngine;

namespace Game.Player
{    
    public class Movement : MonoBehaviour
    {
        private ViewportCheckLimits _checkLimits;

        private Rigidbody2D _rb;
        private float _movementSpeed;

        public void Initialize(Rigidbody2D rb, ViewportCheckLimits checkLimits)
        {
            _rb = rb;
            _checkLimits = checkLimits;
        }

        public bool Move(Vector2 direction)
        {           
            Vector2 targetPosition = _rb.position + direction.normalized * (_movementSpeed * Time.fixedDeltaTime);

            bool limitReached;
            
            targetPosition = _checkLimits.ClampFinalPosition(targetPosition, out limitReached);
            _rb.MovePosition(targetPosition);

            return limitReached;
        }

        public void UpdateSpeed(float movementSpeed)
        {
            _movementSpeed = movementSpeed;
        }
    }
}

