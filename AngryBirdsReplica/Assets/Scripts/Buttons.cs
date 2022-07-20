using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private int current;
    private int next;
    private int maxLevelIndex = 12;

    private void Awake()
    {
        current = PlayerPrefs.GetInt("CurrentScene");
        next = current + 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(current);
        PlayerPrefs.DeleteKey("CurrentScene");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Level01");
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LevelSelectMenu()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void Next()
    {

        if(next==maxLevelIndex)
        {
            SceneManager.LoadScene("GameCleared");
        }
        else
        {
            SceneManager.LoadScene(next);
        }

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
