namespace Game.Ball
{
    public class BallSpeedBooster 
    {
        private float _boostMultiplier;
        public float BoostMultiplier => _boostMultiplier;

        private bool _isBoosted;
        public bool IsBoosted => _isBoosted;

        
        public void EnableBoost(float boost)
        {
            _boostMultiplier = boost;
            _isBoosted = true;
        }

        public void DisableBoost()
        {
            _isBoosted = false;
        }               
    }
}

