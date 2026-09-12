using Game.Core;
using Game.Markers;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private PlayerType playerType;
    
    public void Initialize(PlayerType playerType)
    {
        this.playerType = playerType;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<BallMarker>(out var _))
        {

        }
    }
}
