using UnityEngine;

public class ToggleSwitch : MonoBehaviour, ISwitchable
{
    public GameObject[] Block;

    bool _isReset = false;
    private void Awake()
    {
        GameManager.Instance.OnTurnEnd += Toggle;
        LevelManager.Instance.OnLevelRestart += ResetSwitch;
    }

    private void ResetSwitch()
    {
        _isReset = true;
        for (int i = 0; i < Block.Length; i++)
        {
            if (Block[i].TryGetComponent<ITrap>(out ITrap trap))
            {
                trap.ResetTrap();
            }
        }
    }

    private void OnDestroy()
    {
        if (GameManager.Instance == null) return;
        GameManager.Instance.OnTurnEnd -= Toggle;
        LevelManager.Instance.OnLevelRestart -= ResetSwitch;
    }
    public void Toggle()
    {
        if (_isReset)
        {
            _isReset = false;
            return;
        }
        if(LevelManager.Instance.BlockToggleSwitch)
        {
            LevelManager.Instance.BlockToggleSwitch = false;
            return;
        }
        for (int i = 0; i < Block.Length; i++)
        {
            if (Block[i].TryGetComponent<ITrap>(out ITrap trap))
            {
                trap.Toggle();
            }
        }
    }
}