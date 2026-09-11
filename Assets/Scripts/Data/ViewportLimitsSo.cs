using UnityEngine;

[CreateAssetMenu(fileName = "ViewportLimitsSo", menuName = "Scriptable Objects/ViewportLimitsSo")]
public class ViewportLimitsSo : ScriptableObject
{
    [Range(0, 1)]
    [SerializeField] private float _mixX;
    public float MinX => _mixX;

    [Range(0, 1)]
    [SerializeField] private float _maxX;
    public float MaxX => _maxX;

    [Range(0, 1)]
    [SerializeField] private float _minY;
    public float MinY => _minY;

    [Range(0, 1)]
    [SerializeField] private float _maxY;
    public float MaxY => _maxY;

}
