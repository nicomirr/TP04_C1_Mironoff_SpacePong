using UnityEngine;
using System.Collections;
using Game.Data;

namespace Game.Ball
{
    public class BallLauncher 
    {
        private readonly float _launchForce;
        private readonly float _launchDelay;

        private readonly Rigidbody2D _rb;

        private bool _isLaunched;
        public bool IsLaunched => _isLaunched;

        public BallLauncher(Rigidbody2D rb, BallConfigurationSo data)
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
        }

        public void ResetLaunchState()
        {
            _isLaunched = false;
        }
    }
}

