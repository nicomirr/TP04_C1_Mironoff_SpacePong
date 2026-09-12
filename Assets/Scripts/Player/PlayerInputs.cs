using UnityEngine;
using UnityEngine.InputSystem;
using Game.Core;

namespace Game.Player
{
    public class PlayerInputs 
    {
        private readonly PlayerType _playerType;
        public PlayerType PlayerType => _playerType;

        private readonly GameControls _playerControls;        

        private InputAction _moveAction; 
        public Vector2 MovementDirection => _moveAction.ReadValue<Vector2>();

        private InputAction _rotateAction; 
        private InputAction _changeColorAction; 

        public bool ChangeColorReleased => _changeColorAction.WasReleasedThisFrame();

        
        public PlayerInputs(PlayerType playerType)
        {
            _playerControls = new GameControls();
            _playerType = playerType;

            EnablePlayerInputs();

            _moveAction.Enable();
            _rotateAction.Enable();
            _changeColorAction.Enable();
        }

        public void Deinitialize()
        {
            _moveAction.Disable();
            _rotateAction.Disable();
            _changeColorAction.Disable();

            _playerControls.Disable();
            _playerControls.Dispose();
        }

        public bool RotationPressed(out float value)
        {
            value = _rotateAction.ReadValue<float>();

            return _rotateAction.WasPressedThisFrame();
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
        }       
                
    }
}


