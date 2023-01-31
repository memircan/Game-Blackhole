using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField]
    private float timeToSpawn = 5f;
    private float timeSinceSpawn;
    private ObjectPool objectPool;

    void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();
    }

    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if(timeSinceSpawn >= timeToSpawn)
        {
            GameObject rock =objectPool.GetPooledObj();
            rock.transform.position = new Vector2(Camera.main.transform.position.x + 12f, Random.Range(0f, 4f)); 
            timeSinceSpawn= 0f;
        }
    }
}
