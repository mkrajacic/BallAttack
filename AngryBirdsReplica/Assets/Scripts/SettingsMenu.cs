using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    public void SetVolumeEffects(float volume)
    {
        audioMixer.SetFloat("SoundEffectsVolume", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void RestartHighscores()
    {
        PlayerPrefs.SetInt("levelReached", 1);
        for (int i = 1; i <=9 ; i++)
        {
            if(i>9)
            {
                PlayerPrefs.DeleteKey("HighScoreLevel" + i);
            }
            else
            {
                PlayerPrefs.DeleteKey("HighScoreLevel0" + i);
            }
        }
    }
}
