using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameSetting : MonoBehaviour
{

    [SerializeField]
    GameObject ingameSettingUI;
    void Update()
   {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleWindow();
        }
    }

    public void ToggleWindow()
    {
        bool isActive = ingameSettingUI.activeSelf;
        ingameSettingUI.SetActive(!isActive);

    }
    public void Resume()
    {
        SoundManager.Instance.UnPause();
        ingameSettingUI.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Pause()
    {
        SoundManager.Instance.Pause();
        ingameSettingUI.SetActive(false);
        Time.timeScale = 0f;
    }

    public void MainMenu()
    {
        SceneManagerScript.Instance.LoadScene("MenuScene");
        SoundManager.Instance.PlayBGM("TitleBGM");
    }

}
