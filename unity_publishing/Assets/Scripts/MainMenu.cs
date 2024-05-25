using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;

    public void PlayMaze()
    {
        trapMat.color = new Color32(255, 0, 0, 255);
        goalMat.color = new Color32(0, 255, 0, 255);
      
        if (colorblindMode !=null && colorblindMode.isOn)
        {
            trapMat.color = new Color32(255, 112, 0, 255);
            goalMat.color = Color.blue;
        }
        SceneManager.LoadScene("Maze");
    }
    public void QuitMaze()
    {
        UnityEngine.Debug.Log("Quit Game");
        Application.Quit();
    }
}