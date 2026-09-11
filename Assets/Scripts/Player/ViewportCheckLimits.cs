using UnityEngine;
using Game.Player.Configuration;

namespace Game.Player
{
    public class ViewportCheckLimits
    {
        private const float TOLERANCE = 0.00001f;

        private Camera _camera;

        private ViewportLimitsSo _viewportLimits;
        public ViewportLimitsSo ViewportLimits => _viewportLimits;

        public ViewportCheckLimits(ViewportLimitsSo viewportLimits)
        {
            _camera = Camera.main;
            _viewportLimits = viewportLimits;
        }

        public Vector2 ClampFinalPosition(Vector2 position, out bool movementBlocked)
        {
            Vector3 viewportPointPosition = _camera.WorldToViewportPoint(position);

            Vector3 unclampedPosition = viewportPointPosition;

            viewportPointPosition.x = Mathf.Clamp(viewportPointPosition.x,
                _viewportLimits.MinX, _viewportLimits.MaxX);

            viewportPointPosition.y = Mathf.Clamp(viewportPointPosition.y,
                _viewportLimits.MinY, _viewportLimits.MaxY);

            movementBlocked = Mathf.Abs(unclampedPosition.x - viewportPointPosition.x) > TOLERANCE ||
                Mathf.Abs(unclampedPosition.y - viewportPointPosition.y) > TOLERANCE;

            return _camera.ViewportToWorldPoint(viewportPointPosition);
        }
    }

}
