using UnityEngine;
using System.Collections;
using Game.Data;

namespace Game.Ball
{
    [RequireComponent(typeof(BallLauncher))]
    [RequireComponent(typeof(BallDirectionCorrector))]
    [RequireComponent(typeof(BallMovement))]
    [RequireComponent(typeof(BallHitCounter))]
    [RequireComponent(typeof(Rigidbody2D))]

    public class BallController : MonoBehaviour
    {
        [SerializeField] private BallConfigurationSo _data;

        private BallLauncher _ballLauncher;
        private BallDirectionCorrector _ballDirectionCorrector;
        private BallMovement _ballMovement;
        private BallHitCounter _ballHitCounter;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _ballLauncher = GetComponent<BallLauncher>();
            _ballDirectionCorrector  = GetComponent<BallDirectionCorrector>();
            _ballMovement = GetComponent<BallMovement>();
            _ballHitCounter = GetComponent<BallHitCounter>();

            _rb = GetComponent<Rigidbody2D>();

            _ballLauncher.Initialize(_rb, _data);
            _ballDirectionCorrector.Initialize(_data);
            _ballMovement.Initialize(_rb, _data);
        }

        private IEnumerator Start()
        {
            yield return _ballLauncher.LaunchRoutine();
        }

        private void FixedUpdate()
        {
            HandleMovement();
        }

        private void OnDestroy()
        {
            _ballMovement.Deinitialize();
        }

        private void HandleMovement()
        {
            if (!_ballLauncher.IsLaunched) return;

            Vector2 direction = _ballDirectionCorrector.GetAdjustedDirection(_rb.linearVelocity);
            _ballMovement.HandleMovement(direction);
        }

    }
}

