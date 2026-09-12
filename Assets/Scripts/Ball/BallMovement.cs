using UnityEngine;

namespace Game.Ball
{
    public class BallMovement 
    {                
        private readonly Rigidbody2D _rb;
           
        public BallMovement(Rigidbody2D rb)
        {
            _rb = rb;                  
        }

        public void HandleMovement(Vector2 direction, float speed)
        {
            _rb.linearVelocity = direction.normalized * speed;
        }

        public void Reset()
        {
            _rb.linearVelocity = Vector2.zero;
            _rb.angularVelocity = 0f;
        }

    }
}

