using UnityEngine;

namespace Game.Player
{    
    public class Movement
    {
        private ViewportCheckLimits _checkLimits;

        private Rigidbody2D _rb;
        private float _movementSpeed;

        public Movement(Rigidbody2D rb, ViewportCheckLimits checkLimits)
        {
            _rb = rb;
            _checkLimits = checkLimits;
        }

        public bool Move(Vector2 direction)
        {           
            Vector2 targetPosition = _rb.position + direction.normalized * (_movementSpeed * Time.fixedDeltaTime);

            bool movementBlocked;
            
            targetPosition = _checkLimits.ClampFinalPosition(targetPosition, out movementBlocked);
            _rb.MovePosition(targetPosition);

            return movementBlocked;
        }

        public void UpdateSpeed(float movementSpeed)
        {
            _movementSpeed = movementSpeed;
        }
    }
}

