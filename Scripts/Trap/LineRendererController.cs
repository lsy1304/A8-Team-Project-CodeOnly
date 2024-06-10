using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();

        _lineRenderer.positionCount = 2;        
    }

    public void Play(Vector3 start, Vector3 end)
    {
        _lineRenderer.enabled = true;
        _lineRenderer.SetPosition(0, start);
        _lineRenderer.SetPosition(1, end);
        _lineRenderer.startWidth = 0.4f;
        _lineRenderer.endWidth = 0.4f;
    }

    public void Stop()
    {
        _lineRenderer.enabled = false;
    }
}