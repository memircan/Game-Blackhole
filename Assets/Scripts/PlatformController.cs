using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField]
    GameObject platformPref;

    [SerializeField]
    GameObject playerPref;

    List<GameObject> platforms = new List<GameObject>();

    Vector2 platformPos;
    Vector2 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        PlatformCreate();
    }

    // Update is called once per frame
    void Update()
    {
        if (platforms[platforms.Count - 1].transform.position.x < Camera.main.transform.position.x + ScreenCalculator.instance.Width)
        {
            PlatformMove();
        }
    }

    void PlatformCreate()
    {
        platformPos = new Vector2(0, 0);
        playerPos = new Vector2(0, 0.5f);
        GameObject player = Instantiate(playerPref, playerPos, Quaternion.identity);

        for (int i = 0; i < 16; i++)
        {
            GameObject platform = Instantiate(platformPref, platformPos, Quaternion.identity);
            platforms.Add(platform);
            nextPlatformPos();
        }
    }


    public void PlatformMove()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject temp;
            temp = platforms[i + 8];
            platforms[i + 8] = platforms[i];
            platforms[i] = temp;
            platforms[i + 8].transform.position = platformPos;
            nextPlatformPos();
        }
    }


    void nextPlatformPos()
    {
        platformPos.x += Random.Range(3f, 6f);
        platformPos.y = Random.Range(-1.5f, 1.7f);


    }
}
