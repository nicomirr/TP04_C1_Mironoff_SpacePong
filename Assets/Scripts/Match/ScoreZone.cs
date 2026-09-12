using UnityEngine;
using Game.Core;
using Game.Markers;
using Game.Events;

public class ScoreZone : MonoBehaviour
{
    [SerializeField] private PlayerType _pointRecipient;
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<BallMarker>(out var _))
        {
            MatchEvents.RaisePointScored(_pointRecipient);
        }
    }
}
