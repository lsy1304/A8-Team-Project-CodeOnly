using UnityEngine;

public class LaserTrap : MonoBehaviour, ITrap
{    
    public LineRendererController _visualLine;
    public float distance;

    public bool DefaultState;

    Vector3 _ray;
    Vector3 _startPosition;
    Vector3 _endPosition;   
    RaycastHit hit;

    bool _isOn = true;
        
    private void Awake()
    {                  
        _visualLine = GetComponentInChildren<LineRendererController>();       
        _startPosition = new Vector3(0.3f, 0, 0);
        _ray = transform.position + transform.up * GetComponent<Collider>().bounds.extents.y;
        _isOn = DefaultState;
    }

    private void Update()
    {   
        if(_isOn) LaserBeam();                
    }

    private void LaserBeam()
    {
        if (Physics.Raycast(_ray, transform.up, out hit))
        {
            if (hit.collider.CompareTag("Player") || hit.collider.CompareTag("Wall"))
            {                
                if (_endPosition.x <= 0)
                {
                    _endPosition = new Vector3(0, 0, 0);
                }

                _endPosition = new Vector3(hit.distance * 0.9f, 0, 0);

                if (hit.collider.CompareTag("Player"))
                    hit.transform.GetComponent<PlayerController>().Die();
            }
        }
        _visualLine.Play(_startPosition, _endPosition);
    }

    public void Toggle()
    {
        _isOn = !_isOn;
        if(!_isOn) _visualLine.Stop();
    }

    public void ResetTrap()
    {
        _isOn = DefaultState;
        if(!_isOn) _visualLine.Stop();
    }
}