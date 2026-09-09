using UnityEngine;

namespace Game.Player
{
    public class Appearance : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        public void Initialize()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        public Color32 RandomizeColor()
        {
            byte r = (byte)Random.Range(0, 256);
            byte g = (byte)Random.Range(0, 256);
            byte b = (byte)Random.Range(0, 256);

            Color32 color = new Color32(r, g, b, 1);

            _spriteRenderer.color = color;

            return color;
        }

        public void ChangeColor(Color32 color)
        {
            _spriteRenderer.color = color;
        }
    }
}

