﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void OnClickStartButton()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("LevelChoice");
    }

    public void OnClickStartLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnClickStartLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void OnClickHelpButton()
    {
        SceneManager.LoadScene("Help");
    }

    public void OnClickCreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnClickExitGameButton()
    {
        Application.Quit();
    }

    public void OnClickMainMenu()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }
}
