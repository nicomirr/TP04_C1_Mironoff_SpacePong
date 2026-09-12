using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "BallConfigurationSo", menuName = "Scriptable Objects/BallConfigurationSo")]
    public class BallConfigurationSo : ScriptableObject
    {
        [SerializeField] private Vector2 _startingPos;
        public Vector2 StartPosition => _startingPos;

        [SerializeField] private float _launchForce;
        public float LaunchForce => _launchForce;

        [SerializeField] private float _launchDelay;
        public float LaunchDelay => _launchDelay;

        [SerializeField] private float _speedIncrease;
        public float SpeedIncrease => _speedIncrease;

        [SerializeField] private int _hitsRequiredToSpeedUp;
        public int HitsRequiredToSpeedUp => _hitsRequiredToSpeedUp;

        [SerializeField] private float _initialSpeed;
        public float InitialSpeed => _initialSpeed;

        [SerializeField] private float _maxSpeed;
        public float MaxSpeed => _maxSpeed;

        [SerializeField] private float _minHorizontalXDirection;
        public float MinHorizontalXDirection => _minHorizontalXDirection;

        [SerializeField] private float _maxHorizontalXDirection;
        public float MaxHorizontalXdirection => _maxHorizontalXDirection;

    }
}


