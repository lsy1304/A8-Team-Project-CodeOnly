using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : Singleton<SceneManagerScript>
{
    //필요한 씬 부르기
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //현재씬 불러오기
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //종료
    public void QuitGame()
    {
        Application.Quit();
    }
}
