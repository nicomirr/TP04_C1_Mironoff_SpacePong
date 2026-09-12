using UnityEngine;
using System.Collections;
using Game.Data;
using Game.Events;
using Game.Core;

namespace Game.Player
{
    //DEJO ESTO SEPARADO?
    public class PlayerDefense : MonoBehaviour
    {
        [SerializeField] private GameObject _defenseBody;
        
        private PlayerType _playerType;
        private bool _isEnabled;

        public void Initialize(DefenseConfigurationSo data)
        {
            _playerType = data.PlayerType;
            this.transform.position = data.Position;

            PowerUpEvents.OnDefenseActivated += TryEnableDefense;
        }

        private void Start()
        {
            _defenseBody.SetActive(false);
        }

        private void OnDestroy()
        {
            PowerUpEvents.OnDefenseActivated -= TryEnableDefense;
        }

        private void TryEnableDefense(PlayerType playerType, float time)
        {
            if (_playerType != playerType) return;

            if (_isEnabled)
                StopAllCoroutines();

            StartCoroutine(EnableDefenseRoutine(time));
        }

        private IEnumerator EnableDefenseRoutine(float time)
        {
            _isEnabled = true;
            _defenseBody.SetActive(true);

            yield return new WaitForSeconds(time);

            _isEnabled = false;
            _defenseBody.SetActive(false);
        }

    }
}

