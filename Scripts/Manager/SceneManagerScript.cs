using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : Singleton<SceneManagerScript>
{
    //�ʿ��� �� �θ���
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //����� �ҷ�����
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //����
    public void QuitGame()
    {
        Application.Quit();
    }
}
