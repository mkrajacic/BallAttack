using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Ball player;
    [HideInInspector]
    public string GameState;
    public bool EnemiesDestroyed = false;

    private List<GameObject> Bricks;
    private List<GameObject> Player;
    private List<GameObject> Enemies;
    public int levelToUnlock = 2;

    void Start()
    {
        Bricks = new List<GameObject>(GameObject.FindGameObjectsWithTag("Brick"));
        Player = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        Enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
    }
    void Update()
    {
        if (AllEnemiesDestroyed())
        {
            EnemiesDestroyed = true;
            GameState = "Won";
            if (player.attempt==1)
            {
                PlayerPrefs.SetInt("ExtraLifes", 2);
            }else if(player.attempt == 2)
            {
                PlayerPrefs.SetInt("ExtraLifes", 1);
            }
            else if(player.attempt == 3)
            {
                PlayerPrefs.SetInt("ExtraLifes", 0);
            }

        }else if(!AllEnemiesDestroyed())
        {
            if ((player.attempt!=1) && (player.attempt!=2) && (player.attempt!=3))
            {
                GameState = "Lost";
            }
        }


        StartCoroutine("LoadScreen");

    }

    private bool AllEnemiesDestroyed()
    {
        return Enemies.All(x => x == null);
    }

    IEnumerator LoadScreen()
    {
        switch (GameState)
        {
            case "Won":
                yield return new WaitForSeconds(1.3f);
                if(levelToUnlock>=9)
                {
                    SceneManager.LoadScene("GameCleared");
                    PlayerPrefs.SetInt("levelReached", levelToUnlock);
                }
                PlayerPrefs.SetInt("CurrentScene", SceneManager.GetActiveScene().buildIndex);
                PlayerPrefs.SetInt("levelReached", levelToUnlock);
                SceneManager.LoadScene("Victory");
                break;

            case "Lost":
                yield return new WaitForSeconds(2.0f);
                PlayerPrefs.SetInt("CurrentScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene("Defeat");
                break;

            default:
                break;
        }
    }
}
