using UnityEngine;
using Game.Gameplay;
using Game.Player.Configuration;

namespace Game.Player
{
    [RequireComponent(typeof(PlayerInputs))]
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(Rotation))]
    [RequireComponent(typeof(Appearance))]
    [RequireComponent(typeof(PaddleScaler))]
    [RequireComponent(typeof(Rigidbody2D))]

    public class PlayerController : MonoBehaviour
    {
        private PlayerInputs _playerInputs;
        private Movement _movement;
        private Rotation _rotation;
        private Appearance _appearance;
        private PaddleScaler _paddleScaler;

        private Rigidbody2D _rb;
        
        private void Start()
        {
            PlayerEvents.RaisePlayerInitialized(_playerInputs.PlayerType);
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

        private void OnDestroy()
        {
            _playerInputs.Deinitialize();

            PlayerEvents.OnPlayerMovementSpeedUpdated -= TryChangeMovementSpeed;
            PlayerEvents.OnPlayerColorUpdated -= TryChangeColor;
            PlayerEvents.OnPlayerSizeUpdated -= TryChangeSize;
            GameplayEvents.OnPaddleGrowthActivated -= TryActivatePaddleGrowth;
        }

        public void Initialize(PlayerConfigurationSo configuration)
        {
            _playerInputs = GetComponent<PlayerInputs>();
            _movement = GetComponent<Movement>();
            _rotation = GetComponent<Rotation>();
            _appearance = GetComponent<Appearance>();
            _paddleScaler = GetComponent<PaddleScaler>();

            _rb = GetComponent<Rigidbody2D>();

            _playerInputs.Initialize(configuration.PlayerType);

            ViewportCheckLimits checkLimits = new ViewportCheckLimits(configuration.ViewportLimits);
            _movement.Initialize(_rb, checkLimits);

            _rotation.Initialize(_rb, configuration.Rotation);
            _appearance.Initialize();
            _paddleScaler.Initialize();

            _rb.position = configuration.InitialPosition;

            PlayerEvents.OnPlayerMovementSpeedUpdated += TryChangeMovementSpeed;
            PlayerEvents.OnPlayerColorUpdated += TryChangeColor;
            PlayerEvents.OnPlayerSizeUpdated += TryChangeSize;
            GameplayEvents.OnPaddleGrowthActivated += TryActivatePaddleGrowth;
        }


        private void HandleMovement()
        {
            _movement.Move(_playerInputs.MovementDirection);
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
            if(_playerInputs.ChangeColorReleased)
            {
                Color32 color = _appearance.RandomizeColor();

                PlayerEvents.RaisePlayerColorRandomized(_playerInputs.PlayerType, color);
            }
        }        

        private void TryChangeMovementSpeed(PlayerType player, float speed)
        {
            if (_playerInputs.PlayerType != player) return;

            _movement.UpdateSpeed(speed);
        }

        private void TryChangeColor(PlayerType player, Color32 color)
        {
            if (_playerInputs.PlayerType != player) return;
            
            _appearance.ChangeColor(color);
        }

        private void TryChangeSize(PlayerType player, float scale)
        {
            if (_playerInputs.PlayerType != player) return;

            _paddleScaler.ChangeScale(scale);
        }

        private void TryActivatePaddleGrowth(PlayerType player, float time, float growthFactor)
        {
            if (_playerInputs.PlayerType != player) return;

            _paddleScaler.EnablePaddleGrowth(time, growthFactor);
        }

    }
}

