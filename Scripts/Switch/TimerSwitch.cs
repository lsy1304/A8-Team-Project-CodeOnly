using UnityEngine;

public class TimerSwitch : MonoBehaviour, ISwitchable
{
    [SerializeField]
    public int TurnLimit;

    public int _turnNum;
    public bool _isTouch = false;
    public GameObject[] obj;

    int _activateTurn;
    bool _switchOn = false;
    bool _isReset = false;

    private void Awake()
    {
        GameManager.Instance.OnTurnEnd += Toggle;
        LevelManager.Instance.OnLevelRestart += ResetSwitch;
    }

    private void OnDestroy()
    {
        if (GameManager.Instance == null) return;
        GameManager.Instance.OnTurnEnd -= Toggle;
        LevelManager.Instance.OnLevelRestart -= ResetSwitch;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_switchOn && !_isTouch) return;
            _switchOn = true;
            On();
        }
    }

    private void ResetSwitch()
    {
        _turnNum = 0;
        _isReset = true;
        _switchOn = false;
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i].TryGetComponent<ITrap>(out ITrap trap))
            {
                trap.ResetTrap();
            }
        }
    }

    private void On()
    {
        _turnNum = 0;
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i].TryGetComponent<ITrap>(out ITrap trap))
            {
                trap.Toggle();
            }
        }
    }

    public void Toggle()
    {
        if(_isReset)
        {
            _isReset = false;
            return;
        }
        if (_switchOn) _turnNum++;
        if (_turnNum <= TurnLimit) return;
        _switchOn = false;
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i].TryGetComponent<ITrap>(out ITrap trap))
            {
                trap.Toggle();
            }
        }
        _turnNum = 0;
    }
}
