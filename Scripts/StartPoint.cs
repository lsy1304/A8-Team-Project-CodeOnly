using UnityEngine;

public class StartPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            LevelManager.Instance.UpdateLevel();
        }
    }
}
