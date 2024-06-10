using UnityEngine;

public class DontDestroyContainer : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
