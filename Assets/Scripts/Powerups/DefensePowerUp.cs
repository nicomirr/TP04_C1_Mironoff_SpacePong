using Game.Gameplay;
using UnityEngine;
using Game.Data;
using Game.Ball;

namespace Game.Player
{
    public class DefensePowerUp : MonoBehaviour
    {
        [SerializeField] private TimedPowerupDataSo _data;

        private void Activate(PlayerType playerType)
        {
            GameplayEvents.RaiseDefenseActivated(playerType, _data.Time);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<BallController>(out var ball))
            {
                Activate(ball.LastPlayerHit);
                this.gameObject.SetActive(false);
            }
        }
    }
}

