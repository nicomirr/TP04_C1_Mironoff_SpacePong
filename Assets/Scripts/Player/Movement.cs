using UnityEngine;

namespace Game.Player
{
    //CLAMPEAR MOVIMIENTO 

    public class Movement : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private float _movementSpeed;

        public void Initialize(Rigidbody2D rb)
        {
            _rb = rb;
        }

        public void Move(float direction)
        {
            Vector2 targetPosition = _rb.position + Vector2.up * (direction * _movementSpeed * Time.fixedDeltaTime);          
            _rb.MovePosition(targetPosition);
        }

        public void UpdateSpeed(float movementSpeed)
        {
            _movementSpeed = movementSpeed;
        }
    }
}

