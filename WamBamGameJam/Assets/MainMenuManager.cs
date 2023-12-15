using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenuManager : MonoBehaviour
{

    public string LevelName; 

    public void OnStartButtonClicked()
    {
        SceneManager.LoadSceneAsync(LevelName);
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }

}
