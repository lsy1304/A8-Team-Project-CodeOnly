using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public GameObject stageSelectUI;

    private void Start()
    {
        SoundManager.Instance.PlayBGM("TitleBGM");
        
    }
    public void OnClickStart()
    {
        stageSelectUI.SetActive(true);
    }
    public void ToggleWindow()
    {
        bool isActive = stageSelectUI.activeSelf;
        if (isActive)
        {
            stageSelectUI.SetActive(!isActive);
        }
    }
  

    public void OnClickExit()
    {
        SceneManagerScript.Instance.QuitGame();

        //에디터에서 종료
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
