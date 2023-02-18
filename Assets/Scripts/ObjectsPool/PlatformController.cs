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

    Camera _camera;
    Vector2 platformPos;
    Vector2 playerPos;

    int poolSize = 8;
    int halfSize = 4;

    // Start is called before the first frame update
    void Start()
    {
        PlatformCreate();
        _camera = Camera.main;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (platforms[platforms.Count - 1].transform.position.x < _camera.transform.position.x + ScreenCalculator.instance.Width)
        {
            PlatformMove();
        }
    }

    void PlatformCreate()
    {
        platformPos = new Vector2(0, 0);
        playerPos = new Vector2(0, 0.5f);
        GameObject player = Instantiate(playerPref, playerPos, Quaternion.identity);

        for (int i = 0; i < poolSize; i++)
        {
            GameObject platform = Instantiate(platformPref, platformPos, Quaternion.identity);
            platforms.Add(platform);
            nextPlatformPos();
        }
    }


    public void PlatformMove()
    {
        for (int i = 0; i < halfSize; i++)
        {
            GameObject temp;
            temp = platforms[i + halfSize];
            platforms[i + halfSize] = platforms[i];
            platforms[i] = temp;
            platforms[i + halfSize].transform.position = platformPos;
            nextPlatformPos();
        }
    }


    void nextPlatformPos()
    {
        platformPos.x += Random.Range(3.5f, 6f);
        platformPos.y = Random.Range(-2f, 1.7f);
    }
}
