using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    //[SerializeField]
    //private float timeToSpawn = 5f;
    //private float timeSinceSpawn;

    [SerializeField]
    int poolSize=5;

    private Queue<GameObject> poolObjects;

    void Update()
    {
        // Spawner codes

        //timeSinceSpawn += Time.deltaTime;
        //if (timeSinceSpawn >= timeToSpawn)
        //{
        //    GameObject rock = GetPooledObj();
        //    rock.transform.position = new Vector2(Camera.main.transform.position.x + 12f, Random.Range(0f, 4f));
        //    timeSinceSpawn = 0f;
        //}      
    }

    void Start()
    {
        poolObjects = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject rock = Instantiate(prefab);
            rock.SetActive(false);
            poolObjects.Enqueue(rock);

        }

        StartCoroutine(SpawnRoutine());
    }


    public GameObject GetPooledObj() 
    {
        if(poolObjects.Count >0)
        {
            GameObject obj = poolObjects.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            return Instantiate(prefab);
        }
    }
    public void ReturnToPool( GameObject obj )
    {      
        poolObjects.Enqueue(obj);
        obj.gameObject.SetActive( false );
    }


    public IEnumerator SpawnRoutine() 
    {
        while (true)
        {           
            GameObject obj =GetPooledObj();

            obj.transform.position = new Vector2(Camera.main.transform.position.x+15f,Random.Range(-3f,3.5f));
                       
            yield return new WaitForSeconds(5f);


            ReturnToPool(obj);
        }
    }


}
