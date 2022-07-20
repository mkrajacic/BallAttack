using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    public Button[] LevelButtons;
    public Image[] LockButtons;

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached",1);

        for(int i=0; i<LevelButtons.Length;i++)
        {
            if(i + 1 > levelReached)
            {
                LevelButtons[i].interactable = false;
            }

        }
        for (int j = 0; j < LockButtons.Length; j++)
        {
            if (j + 2 > levelReached)
            {
                LockButtons[j].enabled = true;
            }
            else
            {
                LockButtons[j].enabled = false;
            }

        }
    }
    public void Select(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

}
