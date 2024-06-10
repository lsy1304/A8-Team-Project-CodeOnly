using UnityEngine;

public class WallTrap : MonoBehaviour, ITrap
{
    Vector3 startPos;
    private void Start()
    {
        startPos = transform.position;
    }
    public void ResetTrap()
    {
        transform.position = startPos;
    }

    public void Toggle()
    {
        transform.position += new Vector3(0f, .95f, 0f) * (transform.position.y < -.3f ? 1 : -1);
    }
}
