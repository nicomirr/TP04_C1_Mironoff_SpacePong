using UnityEngine;
using UnityEngine.InputSystem;
using Game.Core;

namespace Game.Player
{
    public class PlayerInputs 
    {
        private readonly PlayerType _playerType;
        public PlayerType PlayerType => _playerType;

        public Vector2 MovementDirection => _moveAction.ReadValue<Vector2>();
        public bool ChangeColorReleased => _changeColorAction.WasReleasedThisFrame();

        private readonly GameControls _playerControls;        

        private InputAction _moveAction; 
        private InputAction _rotateAction; 
        private InputAction _changeColorAction; 
        
        public PlayerInputs(PlayerType playerType)
        {
            _playerControls = new GameControls();
            _playerType = playerType;

            EnablePlayerInputs();            
        }

        private void EnablePlayerInputs()
        {
            switch (_playerType)
            {
                case PlayerType.PlayerOne:
                    _moveAction = _playerControls.PlayerOne.Move;
                    _rotateAction = _playerControls.PlayerOne.Rotate;
                    _changeColorAction = _playerControls.PlayerOne.ChangeColor;
                    break;

                case PlayerType.PlayerTwo:
                    _moveAction = _playerControls.PlayerTwo.Move;
                    _rotateAction = _playerControls.PlayerTwo.Rotate;
                    _changeColorAction = _playerControls.PlayerTwo.ChangeColor;
                    break;

            }

            _moveAction.Enable();
            _rotateAction.Enable();
            _changeColorAction.Enable();
        }        

        public bool RotationPressed(out float value)
        {
            value = _rotateAction.ReadValue<float>();

            return _rotateAction.WasPressedThisFrame();
        }

        public void Deinitialize()
        {
            _moveAction.Disable();
            _rotateAction.Disable();
            _changeColorAction.Disable();

            _playerControls.Disable();
            _playerControls.Dispose();
        }

    }
}


