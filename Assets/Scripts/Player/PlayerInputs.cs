using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerInputs : MonoBehaviour
    {
        private PlayerType _playerType;
        public PlayerType PlayerType => _playerType;

        private GameControls _playerControls;        

        private InputAction _moveAction; 
        public float MovementDirection => _moveAction.ReadValue<float>();

        private InputAction _rotateAction; 
        private InputAction _changeColorAction; 

        public bool ChangeColorReleased => _changeColorAction.WasReleasedThisFrame();

        public bool RotationPressed(out float value)
        {
            value = _rotateAction.ReadValue<float>();

            return _rotateAction.WasPressedThisFrame();
        }

        public void Initialize(PlayerType playerType)
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


