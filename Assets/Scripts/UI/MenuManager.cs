using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    Sprite[] musicIcon;

    [SerializeField]
    Button musicButton;

    void Start()
    {
        if(Save.isMusicSave() == false)
        {
            Save.MusicOnSetValue(1);
        }
        CheckMusicSetting();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
  
    public void Music()
    {
        if (Save.MusicOnGetValue() == 1)
        {
            Save.MusicOnSetValue(0);
            MusicManager.instance.MusicPlay(false);
            musicButton.image.sprite = musicIcon[0];
        }
        else
        {
            Save.MusicOnSetValue(1);
            MusicManager.instance.MusicPlay(true);
            musicButton.image.sprite = musicIcon[1];
        }
    }


    void CheckMusicSetting()
    {
        if (Save.MusicOnGetValue() == 1)
        {
            musicButton.image.sprite = musicIcon[1];
            MusicManager.instance.MusicPlay(true);
        }
        else
        {
            musicButton.image.sprite = musicIcon[0];
            MusicManager.instance.MusicPlay(false);
        }
    }
}
