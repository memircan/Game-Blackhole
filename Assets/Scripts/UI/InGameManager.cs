using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    [SerializeField]
    Sprite[] musicIcon;

    [SerializeField]
    Button musicButton;

    [SerializeField]
    private GameObject failScreen, pauseScreen;

    [SerializeField]
    private Text scoreText,highScore;
    private int score;

    Camera _camera;

    private void Start()
    {
        CheckMusicSetting();
        _camera= Camera.main;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        score = (int)_camera.transform.position.x;
        scoreText.text = $"Score: {score}";
    }

    public void GameFail()
    {
        Time.timeScale = 0;
        failScreen.SetActive(true);
        Save.ScoreSave(score);       
        highScore.text = $"High Score is { Save.GetScore()}!";
        
    }

    public void GameRestart() 
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void GamePause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameResume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameMenu() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void GameExit()
    {
        Time.timeScale = 1;
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
