using UnityEngine;
using Game.Data;
using Game.Ball;
using Game.Core;
using Game.Events;

namespace Game.PowerUps
{
    public class DefensePowerUp : MonoBehaviour
    {
        [SerializeField] private TimedPowerupDataSo _data;

        private void Activate(PlayerType playerType)
        {
            PowerUpEvents.RaiseDefenseActivated(playerType, _data.Time);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<BallController>(out var ball))
            {
                AudioEvents.RaiseSFXAudioPlayRequested(AudioType.DefensePowSound);

                Activate(ball.LastPlayerHit);
                this.gameObject.SetActive(false);
            }
        }
    }
}

