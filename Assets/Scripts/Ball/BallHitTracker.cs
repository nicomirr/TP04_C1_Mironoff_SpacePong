using Game.Data;
using Game.Player;
using UnityEngine;

public class BallHitTracker : MonoBehaviour
{
    private int _hitsRequiredToSpeedUp;

    private PlayerType _lastPlayer;
    public PlayerType LastPlayer => _lastPlayer;

    private int _hitCount;
    public int HitCount => _hitCount;

    public void Initialize(BallConfigurationSo data)
    {
        _hitsRequiredToSpeedUp = data.HitsRequiredToSpeedUp;
    }

    public void RegisterHit(PlayerType player)
    {
        _lastPlayer = player;
        _hitCount++;        
    }   
    
    public bool TryConsumeSpeedIncrease()
    {
        if (_hitCount >= _hitsRequiredToSpeedUp)
        {
            _hitCount = 0;
            return true;
        }

        return false;
    }
}
