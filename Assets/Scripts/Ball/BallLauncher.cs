using System.Collections;
using UnityEngine;
using Game.Gameplay;
using Game.Data;

namespace Game.Ball
{
    public class BallLauncher : MonoBehaviour
    {
        private float _launchForce;
        private float _launchDelay;

        private Rigidbody2D _rb;

        private bool _isLaunched;
        public bool IsLaunched => _isLaunched;

        public void Initialize(Rigidbody2D rb, BallConfigurationSo data)
        {
            _rb = rb;

            _launchForce = data.LaunchForce;
            _launchDelay = data.LaunchDelay;
        }

        public IEnumerator LaunchRoutine()
        {
            yield return new WaitForSeconds(_launchDelay);

            float randomXDir = Random.value < 0.5f ? -1f : 1f;
            float randomYDir = Random.value < 0.5f ? -1f : 1f;

            Vector2 direction = new Vector2(randomXDir, randomYDir).normalized;

            _rb.AddForce(direction * _launchForce, ForceMode2D.Impulse);

            _isLaunched = true;
            GameplayEvents.RaiseRoundStarted();
        }
    }
}

