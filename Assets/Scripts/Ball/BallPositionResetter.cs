using UnityEngine;
using Game.Data;

namespace Game.Ball
{
    public class BallPositionResetter
    {
        private Rigidbody2D _rb;
        private Vector2 _startPosition;

        public BallPositionResetter(Rigidbody2D rb, BallConfigurationSo data)
        {
            _rb = rb;
            _startPosition = data.StartPosition;
        }

        public void Reset()
        {            
            _rb.position = _startPosition;
        }
    }

}
