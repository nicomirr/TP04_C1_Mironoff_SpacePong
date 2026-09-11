using UnityEngine;
using Game.Data;

public class ViewportCheckLimits 
{
    private Camera _camera;
    private ViewportLimitsSo _viewportLimits;

    public ViewportCheckLimits(ViewportLimitsSo viewportLimits)
    {
        _camera = Camera.main;
        _viewportLimits = viewportLimits;
    }

    public Vector2 ClampFinalPosition(Vector2 position)
    {
        Vector3 viewportPointPosition = _camera.WorldToViewportPoint(position);

        viewportPointPosition.x = Mathf.Clamp(viewportPointPosition.x,
            _viewportLimits.MinX, _viewportLimits.MaxX);

        viewportPointPosition.y = Mathf.Clamp(viewportPointPosition.y,
            _viewportLimits.MinY, _viewportLimits.MaxY);

        return _camera.ViewportToWorldPoint(viewportPointPosition);
    }
}
