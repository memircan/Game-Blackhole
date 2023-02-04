using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int poolSize = 20;

    private Queue<GameObject> bulletQueue;

    private void Start()
    {
        // Initialize the queue and fill it with the bullet prefabs
        bulletQueue = new Queue<GameObject>(poolSize);
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletQueue.Enqueue(bullet);
        }
    }

    public GameObject GetBullet()
    {
        if (bulletQueue.Count > 0)
        {
            GameObject bullet = bulletQueue.Dequeue();
            bullet.SetActive(true);

            return bullet;
        }
        else
        {
            return Instantiate(bulletPrefab);
        }
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletQueue.Enqueue(bullet);
    }
}