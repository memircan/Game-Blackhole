using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject failScreen, pauseScreen;

    

    // Start is called before the first frame update
    public void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GameFail()
    {
        failScreen.SetActive(true);
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
