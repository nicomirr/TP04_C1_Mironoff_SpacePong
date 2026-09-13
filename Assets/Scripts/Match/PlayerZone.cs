using UnityEngine;
using Game.Core;
using Game.Data;
using Game.Events;
using Game.Markers;

namespace Game.Match
{
    public class PlayerZone : MonoBehaviour
    {
        [SerializeField] private PlayerTypeConfigSo _data;
        private PlayerType _pointRecipient;

        private void Start()
        {
            _pointRecipient = _data.Player;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<BallMarker>(out var _))
            {
                MatchEvents.RaiseSideChanged(_pointRecipient);
            }
        }
    }
}

