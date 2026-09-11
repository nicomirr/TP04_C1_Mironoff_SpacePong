using UnityEngine;
using Game.Player.Configuration;

namespace Game.Player
{
    public class ViewportCheckLimits
    {
        private Camera _camera;

        private ViewportLimitsSo _viewportLimits;
        public ViewportLimitsSo ViewportLimits => _viewportLimits;

        public ViewportCheckLimits(ViewportLimitsSo viewportLimits)
        {
            _camera = Camera.main;
            _viewportLimits = viewportLimits;
        }

        public Vector2 ClampFinalPosition(Vector2 position, out bool limitReached)
        {
            Vector3 viewportPointPosition = _camera.WorldToViewportPoint(position);

            viewportPointPosition.x = Mathf.Clamp(viewportPointPosition.x,
                _viewportLimits.MinX, _viewportLimits.MaxX);

            viewportPointPosition.y = Mathf.Clamp(viewportPointPosition.y,
                _viewportLimits.MinY, _viewportLimits.MaxY);

            limitReached = viewportPointPosition.x == ViewportLimits.MinX || viewportPointPosition.x == ViewportLimits.MaxX ||
                viewportPointPosition.y == ViewportLimits.MinY || viewportPointPosition.y == ViewportLimits.MaxY;

            return _camera.ViewportToWorldPoint(viewportPointPosition);
        }
    }

}
