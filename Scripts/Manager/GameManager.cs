using System;

public class GameManager : Singleton<GameManager>
{
    public int TurnCount;
    public event Action OnTurnEnd;

    void Start()
    {
        OnTurnEnd += TurnIncrease;
        LevelManager.Instance.OnLevelClear += TurnReset;
    }

    private void TurnReset()
    {
        TurnCount = -1;
    }

    private void TurnIncrease()
    {
        ++TurnCount;
    }

    public void CallOnTurnEndEvent()
    {
        OnTurnEnd?.Invoke();
    }
}
