using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour
{
    public Text result;
    private int CurrentHighscore;
    public string Level;
    void Start()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("HighScore" + Level, 0).ToString();
        CurrentHighscore = PlayerPrefs.GetInt("HighScore" + Level, 0);
    }

    // Update is called once per frame
    void Update()
    {
        string s = result.GetComponent<Text>().text;
        int r = Convert.ToInt32(s);

        if (r>CurrentHighscore)
        {
            PlayerPrefs.SetInt("HighScore" + Level, r);
        }
    }
}
