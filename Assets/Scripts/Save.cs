using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public static class Save 
{
    public static void ScoreSave(float score)
    {        
        int highScore=PlayerPrefs.GetInt(nameof(highScore), 0);
        if (score > highScore)
        {
            PlayerPrefs.SetFloat(nameof(highScore), score);
        }
    }

    public static void SoundSave()
    {

    }
}
