using UnityEngine;
using Game.Core;
using Game.Data;
using Game.Ball;
using Game.Events;

namespace Game.PowerUps
{
    public class PaddleGrowthPowerUp : MonoBehaviour
    {
        [SerializeField] private PaddleGrowthDataSo _data;

        private void Activate(PlayerType playerType)
        {
            PowerUpEvents.RaisePaddleGrowthActivated(playerType, _data.Time, _data.GrowthFactor);
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

