using Game.Core;
using Game.Events;
using Game.Markers;
using UnityEngine;

namespace Game.Match
{
    public class PlayerZone : MonoBehaviour
    {
        [SerializeField] private PlayerType _pointRecipient;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<BallMarker>(out var _))
            {
                MatchEvents.RaiseSideChanged(_pointRecipient);
            }
        }
    }
}

