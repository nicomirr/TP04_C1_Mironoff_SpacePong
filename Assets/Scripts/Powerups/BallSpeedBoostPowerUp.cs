using UnityEngine;
using Game.Gameplay;
using Game.Data;

namespace Game.PowerUps
{
    public class BallSpeedBoostPowerUp : MonoBehaviour
    {
        [SerializeField] private SpeedPowerUpDataSo data;
        private void Activate()
        {
            GameplayEvents.RaiseBallSpeedBoostActivated(data.SpeedIncrease);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Activate();
            this.gameObject.SetActive(false);
        }
    }

}
