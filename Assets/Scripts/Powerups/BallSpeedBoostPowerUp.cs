using UnityEngine;
using Game.Data;
using Game.Events;

namespace Game.PowerUps
{
    public class BallSpeedBoostPowerUp : MonoBehaviour
    {
        [SerializeField] private SpeedPowerUpDataSo data;
        private void Activate()
        {
            PowerUpEvents.RaiseBallSpeedBoostActivated(data.SpeedIncrease);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            AudioEvents.RaiseSFXAudioPlayRequested(AudioType.BallSpeedPowSound);

            Activate();
            this.gameObject.SetActive(false);
        }
    }

}
