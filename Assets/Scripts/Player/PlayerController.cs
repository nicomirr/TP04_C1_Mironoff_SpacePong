using UnityEngine;
using Game.Gameplay;
using Game.Player.Configuration;
using Game.Markers;

namespace Game.Player
{    
    [RequireComponent(typeof(Rigidbody2D))]

    public class PlayerController : MonoBehaviour
    {
        public PlayerType PlayerType => _playerInputs.PlayerType;

        private PlayerInputs _playerInputs;
        private Movement _movement;
        private Rotation _rotation;
        private ColorChanger _colorChanger;
        private PaddleScaler _paddleScaler;

        private bool _movementLimitReached;

        private Rigidbody2D _rb;
        
        private void Start()
        {
            PlayerEvents.RaisePlayerInitialized(PlayerType);
        }

        private void FixedUpdate()
        {            
            HandleMovement();            
        }

        private void Update()
        {
            HandleRotation();       
            HandleColorChange();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<BallMarker>(out var _))
            {
                RandomizePaddleColor();
            }
        }

        private void OnDestroy()
        {
            _playerInputs.Deinitialize();

            PlayerEvents.OnPlayerMovementSpeedUpdated -= TryChangeMovementSpeed;
            PlayerEvents.OnPlayerColorUpdatedInSettings -= TryChangeColorWithSettings;
            PlayerEvents.OnPlayerSizeUpdatedInSettings -= TryChangeSizeWithSettings;
            GameplayEvents.OnPaddleGrowthActivated -= TryActivatePaddleGrowth;
        }

        public void Initialize(PlayerConfigurationSo configuration)
        {            
            _rb = GetComponent<Rigidbody2D>();

            _playerInputs = new PlayerInputs(configuration.PlayerType);
            
            ViewportCheckLimits checkLimits = new ViewportCheckLimits(configuration.ViewportLimits);
            _movement = new Movement(_rb, checkLimits);
            
            _rotation = new Rotation(_rb, configuration.Rotation);

            _colorChanger = new ColorChanger(GetComponentInChildren<SpriteRenderer>(), 
                configuration.CollidingWithlimitsColor);

            _paddleScaler = new PaddleScaler(GetComponentInChildren<PaddleVisualMarker>().transform);

            _rb.position = configuration.InitialPosition;

            PlayerEvents.OnPlayerMovementSpeedUpdated += TryChangeMovementSpeed;
            PlayerEvents.OnPlayerColorUpdatedInSettings += TryChangeColorWithSettings;
            PlayerEvents.OnPlayerSizeUpdatedInSettings += TryChangeSizeWithSettings;
            GameplayEvents.OnPaddleGrowthActivated += TryActivatePaddleGrowth;
        }


        private void HandleMovement()
        {
            _movementLimitReached = _movement.Move(_playerInputs.MovementDirection);
        }

        private void HandleRotation()
        {
            float rotation;

            if (_playerInputs.RotationPressed(out rotation))
            {
                _rotation.Rotate(rotation);
            }
        }

        private void HandleColorChange()
        {
            if(_movementLimitReached)
            {
                _colorChanger.HandleCollidingWithLimits();
            }            
            else 
            {
                _colorChanger.HandleExitLimitsCollision();                                
            }

            if (_playerInputs.ChangeColorReleased)
            {
                RandomizePaddleColor();
            }
        }        

        private void RandomizePaddleColor()
        {
            Color32 color = _colorChanger.RandomizeColor();
            PlayerEvents.RaisePlayerColorChangedInGameplay(PlayerType, color);
        }

        private void TryChangeMovementSpeed(PlayerType player, float speed)
        {
            if (PlayerType != player) return;

            _movement.UpdateSpeed(speed);
        }

        private void TryChangeColorWithSettings(PlayerType player, Color32 color)
        {
            if (PlayerType != player) return;
            
            _colorChanger.ChangeColorWithSettings(color);
        }

        private void TryChangeSizeWithSettings(PlayerType player, float scale)
        {
            if (PlayerType != player) return;

            _paddleScaler.ChangeScaleWithSettings(scale);
        }

        private void TryActivatePaddleGrowth(PlayerType player, float time, float growthFactor)
        {
            if (PlayerType != player) return;

            if(_paddleScaler.PaddleGrowth)
                StopAllCoroutines();

            StartCoroutine(_paddleScaler.GrowPaddleRoutine(time, growthFactor));
        }        


    }
}

