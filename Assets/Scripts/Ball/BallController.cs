using UnityEngine;
using System.Collections;
using Game.Gameplay;
using Game.Player;
using Game.Data;

namespace Game.Ball
{    
    [RequireComponent(typeof(BallHitTracker))]
    [RequireComponent(typeof(Rigidbody2D))]

    public class BallController : MonoBehaviour
    {
        [SerializeField] private BallConfigurationSo _data;

        private BallHitTracker _ballHitTracker;

        private BallLauncher _ballLauncher;
        private BallMovement _ballMovement;
        private BallSpeed _ballSpeed;
        private BallSpeedBooster _ballSpeedBooster; 
        private BallDirectionCorrector _ballDirectionCorrector;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _ballHitTracker = GetComponent<BallHitTracker>();
            _rb = GetComponent<Rigidbody2D>();

            _ballMovement = new BallMovement(_rb);
            _ballLauncher = new BallLauncher(_rb, _data);
            _ballSpeed = new BallSpeed(_data);
            _ballSpeedBooster = new BallSpeedBooster();
            _ballDirectionCorrector = new BallDirectionCorrector(_data);

            _ballHitTracker.Initialize(_data);


            GameplayEvents.OnBallSpeedBoostActivated += HandleBoostEnable;
        }

        private IEnumerator Start()
        {
            yield return _ballLauncher.LaunchRoutine();
            GameplayEvents.RaiseRoundStarted();
        }

        private void FixedUpdate()
        {
            HandleMovement();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            HandleBoostDisable(collision);
            HandleLastPlayerHitTracking(collision.gameObject);            
        }

        private void OnDestroy()
        {
            GameplayEvents.OnBallSpeedBoostActivated -= HandleBoostEnable;
        }

        private void HandleMovement()
        {
            if (!_ballLauncher.IsLaunched) return;

            Vector2 direction = _ballDirectionCorrector.GetAdjustedDirection(_rb.linearVelocity);

            float speed = CalculateSpeed();

            _ballMovement.HandleMovement(direction, speed);
        }             
        
        private float CalculateSpeed()
        {
            float speed = _ballSpeed.CurrentSpeed;

            speed = _ballSpeedBooster.IsBoosted ? speed * _ballSpeedBooster.BoostMultiplier : speed;

            return speed;
        }

        private void HandleBoostEnable(float boostValue)
        {
            _ballSpeedBooster.EnableBoost(boostValue);
        }

        private void HandleBoostDisable(Collision2D collision)
        {
            if (!_ballSpeedBooster.IsBoosted) return;

            if(collision.gameObject.TryGetComponent<PlayerController>(out var _))
            {
                _ballSpeedBooster.DisableBoost();
            }
        }

        private void HandleLastPlayerHitTracking(GameObject gameObject)
        {
            if (gameObject.TryGetComponent<PlayerInputs>(out PlayerInputs playerInputs))
            {
                _ballHitTracker.RegisterHit(playerInputs.PlayerType);

                if(_ballHitTracker.TryConsumeSpeedIncrease())
                    _ballSpeed.TryIncreaseSpeed();
            }
        }
    }
}

