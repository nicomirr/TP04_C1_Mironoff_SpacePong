using UnityEngine;
using Game.Gameplay;
using Game.Player;
using Game.Data;

public class PaddleGrowthPowerUp : MonoBehaviour
{
    [SerializeField] private PaddleGrowthDataSo _data;

    private void Activate(PlayerType playerType)
    {
        GameplayEvents.RaisePaddleGrowthActivated(playerType, _data.Time, _data.GrowthFactor);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<BallHitTracker>(out BallHitTracker ballHitTracker))
        {
            Activate(ballHitTracker.LastPlayer);
            this.gameObject.SetActive(false);
        }        
    }
}
