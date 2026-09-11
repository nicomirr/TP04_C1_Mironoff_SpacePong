using UnityEngine;

namespace Game.Player
{
    public class ColorChanger : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;        
        
        private Color32 _collidingWithLimitsColor;
        private Color32 _previousColor;

        private bool _collidingLimits;

        public void Initialize(Color32 collidingWithLimitsColor)
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _collidingWithLimitsColor = collidingWithLimitsColor;
        }

        public Color32 HandleCollidingWithLimits()
        {
            _spriteRenderer.color = _collidingWithLimitsColor;
            _collidingLimits = true;

            return _collidingWithLimitsColor;
        }

        public Color32? TryResetColor()
        {
            if (_spriteRenderer.color == _previousColor) return null;

            _spriteRenderer.color = _previousColor;

            return _spriteRenderer.color;
        }

        public Color32 RandomizeColor()
        {
            byte r = (byte)Random.Range(0, 256);
            byte g = (byte)Random.Range(0, 256);
            byte b = (byte)Random.Range(0, 256);

            Color32 color = new Color32(r, g, b, 255);

            _previousColor = color;
            _spriteRenderer.color = color;

            return color;
        }

        public void ChangeColor(Color32 color)
        {
            _spriteRenderer.color = color;
            _previousColor = color;
        }
    }
}

