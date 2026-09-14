using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "PlayerInitialSettings", menuName = "Scriptable Objects/PlayerInitialSettings")]
    public class PlayerInitialSettingsSo : ScriptableObject
    {
        [Range(0, 10)][SerializeField] private float _movementSpeed;
        public float MovementSpeed => _movementSpeed;

        [Range(1.2f, 1.8f)][SerializeField] private float _padSize;
        public float PadSize => _padSize;

        [SerializeField] private Color _padColor;
        public Color PadColor => _padColor;
    }
}

