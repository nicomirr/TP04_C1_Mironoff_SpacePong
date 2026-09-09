using UnityEngine;
using Game.Player;
using Game.Gameplay;
using Game.Data;

//REFACTORIZAR ESTA CLASE
//Hacer un hitcounter en otro script para poder controlar cada cuantos golpes suma velocidad
namespace Game.Ball
{
    public class BallMovement : MonoBehaviour
    {                
        private Rigidbody2D _rb;

        private float _initialSpeed;
        private float _maxSpeed;

        private float _increaseAmountPerHit;

        private float _currentSpeed;
        private float _boostedSpeed;

        //esto va en otro script quizas
        private bool _isBoosted;
              
        private void Start()
        {
            _currentSpeed = _initialSpeed;         
        }

        public void Initialize(Rigidbody2D rb, BallConfigurationSo data)
        {
            _rb = rb;

            _initialSpeed = data.InitialSpeed;
            _maxSpeed = data.MaxSpeed;

            _increaseAmountPerHit = data.SpeedIncreasePerHit;

            GameplayEvents.OnBallSpeedBoostActivated += EnableBoost;
        }

        public void Deinitialize()
        {
            GameplayEvents.OnBallSpeedBoostActivated -= EnableBoost;
        }

        public void HandleMovement(Vector2 direction)
        {
            ApplyVelocity(direction);
        }        

        private void EnableBoost(float speedIncrease)
        {
            _boostedSpeed = _currentSpeed * speedIncrease;
            _isBoosted = true;
        }        

        private void ApplyVelocity(Vector2 direction)
        {
            float speed = _isBoosted? _boostedSpeed : _currentSpeed;

            _rb.linearVelocity = direction.normalized * speed;
        }       

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
            {
                if (_currentSpeed < _maxSpeed)
                    _currentSpeed = Mathf.Clamp(_currentSpeed + _increaseAmountPerHit, _initialSpeed, _maxSpeed);

                if(_isBoosted)
                    _isBoosted = false;
            }
        }
    }
}

