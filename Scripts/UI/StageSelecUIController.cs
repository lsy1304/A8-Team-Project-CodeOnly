using UnityEngine;
using UnityEngine.EventSystems;

public class StageSelecUIController : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManagerScript.Instance.LoadScene("StageScene");
        SoundManager.Instance.PlayBGM("MainBGM");
        SelectStage();
    }
    public void SelectStage()
    {
        string eventButtonName = EventSystem.current.currentSelectedGameObject.name;
        int stageNumber = int.Parse(eventButtonName);
        LevelManager.Instance.CurLevelIdx = stageNumber;
    }
}
