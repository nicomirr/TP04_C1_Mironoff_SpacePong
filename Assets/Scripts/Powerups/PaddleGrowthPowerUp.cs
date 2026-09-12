using UnityEngine;
using Game.Gameplay;
using Game.Player;
using Game.Data;
using Game.Ball;

public class PaddleGrowthPowerUp : MonoBehaviour
{
    [SerializeField] private PaddleGrowthDataSo _data;

    private void Activate(PlayerType playerType)
    {
        GameplayEvents.RaisePaddleGrowthActivated(playerType, _data.Time, _data.GrowthFactor);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<BallController>(out var ball))
        {
            Activate(ball.LastPlayerHit);
            this.gameObject.SetActive(false);
        }        
    }
}
