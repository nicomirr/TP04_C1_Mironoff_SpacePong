using Game.Player;
using UnityEngine;

public class BallHitTracker : MonoBehaviour
{
    private PlayerType _lastPlayer;
    public PlayerType LastPlayer => _lastPlayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerInputs>(out PlayerInputs playerInputs))
        {
            _lastPlayer = playerInputs.PlayerType;
        }
    }
    
}
