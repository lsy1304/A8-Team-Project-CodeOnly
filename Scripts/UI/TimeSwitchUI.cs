using UnityEngine;
using UnityEngine.UI;

public class TimeSwitchUI : MonoBehaviour
{
    [SerializeField]
    TimerSwitch timerSwitch;
    [SerializeField]
    Image timerUI;

    void Start()
    {
        GameManager.Instance.OnTurnEnd += UpdateUI;
        LevelManager.Instance.OnLevelRestart += ResetUI;
        timerUI.fillAmount = 0f;
    }

    private void OnDestroy()
    {
        if (GameManager.Instance == null) return;
        GameManager.Instance.OnTurnEnd -= UpdateUI;
        LevelManager.Instance.OnLevelRestart -= ResetUI;
    }

    private void ResetUI()
    {
        timerUI.fillAmount = 0f;
    }

    private void UpdateUI()
    {
        if (timerSwitch._turnNum == 0)
        {
            timerUI.fillAmount = 0f;
            return;
        }
        timerUI.fillAmount = (float)(timerSwitch.TurnLimit - timerSwitch._turnNum + 1) / timerSwitch.TurnLimit;
    }
}
