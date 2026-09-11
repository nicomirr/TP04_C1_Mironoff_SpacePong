using UnityEngine;

namespace Game.Player
{
    public class Rotation 
    {
        private float _rotationAmount = 10f;

        private Rigidbody2D _rb;

        public Rotation(Rigidbody2D rb, float rotationAmount)
        {
            _rb = rb;
            _rotationAmount = rotationAmount;
        }

        public void Rotate(float direction)
        {
            _rb.MoveRotation(_rb.rotation + (-direction * _rotationAmount));
        }
    }
}

