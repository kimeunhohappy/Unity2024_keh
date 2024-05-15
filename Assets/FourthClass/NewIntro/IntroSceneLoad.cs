using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneLoad : MonoBehaviour
{
    public void LoadGameScene()
    {
        //SceneManager.LoadScene("SampleScene");
        Loading.LoadScene("SampleScene");
    }

    public void LoadOptionScene()
    {
        SceneManager.LoadScene("OptionScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
