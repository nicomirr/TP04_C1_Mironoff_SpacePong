using Game.Gameplay;
using Game.Player;
using UnityEngine;
using Game.Data;

public class DefensePowerUp : MonoBehaviour
{
    [SerializeField] private TimedPowerupDataSo _data;

    private void Activate(PlayerType playerType)
    {
        GameplayEvents.RaiseDefenseActivated(playerType, _data.Time);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<BallHitTracker>(out BallHitTracker ballHitTracker))
        {
            Activate(ballHitTracker.LastPlayer);
            this.gameObject.SetActive(false);
        }
    }
}
