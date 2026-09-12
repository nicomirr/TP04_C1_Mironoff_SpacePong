using UnityEngine;

public class BallTrail
{
    private readonly TrailRenderer _trailRenderer;

    public BallTrail(TrailRenderer trailRenderer)
    {
        _trailRenderer = trailRenderer;
    }

    public void Enable()
    {
        _trailRenderer.emitting = true;
    }

    public void Disable()
    {
        _trailRenderer.emitting = false;
    }
}
