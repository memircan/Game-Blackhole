using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject failScreen, pauseScreen;

    [SerializeField]
    private Text scoreText;
    private int score;

    // Update is called once per frame
    void Update()
    {
        score = (int)Camera.main.transform.position.x;
        scoreText.text = "Score: " + score;
    }


    public void GameFail()
    {
        Time.timeScale = 0;
        failScreen.SetActive(true);
        Save.ScoreSave(score);
        
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

    public void Sound()
    {
       
    }
}
