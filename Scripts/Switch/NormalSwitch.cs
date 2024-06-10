using UnityEngine;

public class NormalSwitch : MonoBehaviour, ISwitchable
{
    public GameObject[] Block;
    bool _isTouch = false;

    private void Awake()
    {
        LevelManager.Instance.OnLevelRestart += ResetSwitch;
    }

    private void OnDestroy()
    {
        if (GameManager.Instance == null) return;
        LevelManager.Instance.OnLevelRestart -= ResetSwitch;
    }

    private void ResetSwitch()
    {
        for(int i =0; i<Block.Length; i++)
        {
            if (Block[i].TryGetComponent<ITrap>(out ITrap trap))
            {
                trap.ResetTrap();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Toggle();
        }
    }
    public void Toggle()
    {
        for (int i = 0; i < Block.Length; i++)
        {
            if (Block[i].TryGetComponent<ITrap>(out ITrap trap))
            {
                trap.Toggle();
            }
        }
        _isTouch = !_isTouch;
    }
}