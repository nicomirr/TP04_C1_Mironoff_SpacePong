using Game.Data;
using UnityEngine;

public class BallSpeed
{
    private readonly float _increaseAmount;

    private readonly float _startingSpeed;

    private readonly float _maxSpeed;
    
    private float _currentSpeed;
    public float CurrentSpeed => _currentSpeed;

    public BallSpeed(BallConfigurationSo data)
    {        
        _increaseAmount = data.SpeedIncrease;

        _maxSpeed = data.MaxSpeed;

        _startingSpeed = data.InitialSpeed;

        _currentSpeed = data.InitialSpeed;


    }

    public void TryIncreaseSpeed()
    {
        if (_currentSpeed >= _maxSpeed) return;
        _currentSpeed = Mathf.Min(_currentSpeed + _increaseAmount, _maxSpeed);
    }

    public void Reset()
    {
        _currentSpeed = _startingSpeed;
    }
}
