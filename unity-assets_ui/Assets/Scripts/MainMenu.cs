using System;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
//using System.Runtime.Hosting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public SettingsSO settings;

    public void LevelSelect(int level)
    {

        settings.LastScene = 4;
        SceneManager.LoadScene(level);
    }

    public void Options()
    {
        settings.LastScene = 4;
        SceneManager.LoadScene(3);
    }

    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
