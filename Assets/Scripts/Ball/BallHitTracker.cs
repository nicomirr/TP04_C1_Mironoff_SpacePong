using Game.Data;
using Game.Core;

public class BallHitTracker 
{
    private int _hitsRequiredToSpeedUp;

    private PlayerType _lastPlayer;
    public PlayerType LastPlayer => _lastPlayer;

    private int _hitCount;
    public int HitCount => _hitCount;

    public BallHitTracker(BallConfigurationSo data)
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

    public void Reset()
    {
        _hitCount = 0;
    }
}
