using UnityEngine;

public class FloorGrid : MonoBehaviour
{
    private void Start()
    {
        SetFloorGrid();
    }

    void SetFloorGrid()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Material material = new Material(Shader.Find("Standard"));
        Texture texture = Resources.Load<Texture>("grid");
        material.mainTexture = texture;
        material.mainTextureScale = new Vector2(transform.localScale.x * 10, transform.localScale.z * 10);
        meshRenderer.material = material;
    }
}
