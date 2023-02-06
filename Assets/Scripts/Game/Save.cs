using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public static class Save 
{
    public static string musicOn = "musicOn";

    public static void ScoreSave(float score)
    {        
        int highScore=PlayerPrefs.GetInt(nameof(highScore), 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt(nameof(highScore), (int)score);
        }
    }

    public static int GetScore()
    {
        int highScore = PlayerPrefs.GetInt(nameof(highScore));
        return highScore;
    }

    public static void MusicOnSetValue(int value)
    {
        PlayerPrefs.SetInt(Save.musicOn,value);
    }

    public static int MusicOnGetValue()
    {
        return PlayerPrefs.GetInt(Save.musicOn);
    }

    public static bool isMusicSave()
    {
        if (PlayerPrefs.HasKey(Save.musicOn))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
