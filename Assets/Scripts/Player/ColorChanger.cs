using UnityEngine;

namespace Game.Player
{
    public class ColorChanger
    {
        private SpriteRenderer _spriteRenderer;        
        
        private Color32 _collidingWithLimitsColor;
        private Color32 _previousColor;

        private bool _collidingWithLimits;

        public ColorChanger(SpriteRenderer spriteRenderer, Color32 collidingWithLimitsColor)
        {
            _spriteRenderer = spriteRenderer;
            _collidingWithLimitsColor = collidingWithLimitsColor;
        }

        public Color32 HandleCollidingWithLimits()
        {
            _spriteRenderer.color = _collidingWithLimitsColor;         
            _collidingWithLimits = true;

            return _collidingWithLimitsColor;
        }

        public Color32? HandleExitLimitsCollision()
        {
            if (_spriteRenderer.color == _previousColor) return null;

            _spriteRenderer.color = _previousColor;
            _collidingWithLimits = false;

            return _spriteRenderer.color;
        }

        public Color32 RandomizeColor()
        {           
            byte r = (byte)Random.Range(0, 256);
            byte g = (byte)Random.Range(0, 256);
            byte b = (byte)Random.Range(0, 256);

            Color32 color = new Color32(r, g, b, 255);

            _previousColor = color;

            if(!_collidingWithLimits)
            {
                _spriteRenderer.color = color;
            }

            return color;
        }

        public void ChangeColorWithSettings(Color32 color)
        {
            _previousColor = color;
            if (_collidingWithLimits) return;

            _spriteRenderer.color = color;
        }
    }
}

