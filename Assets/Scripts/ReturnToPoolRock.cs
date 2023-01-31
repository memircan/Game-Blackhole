using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPoolRock : MonoBehaviour
{
    private ObjectPool objectPool;

    
    // Start is called before the first frame update
    public void Start()
    {
        objectPool=FindObjectOfType<ObjectPool>();
        
    }

    



    // Update is called once per frame
    void OnDisable()
    {
        if (objectPool != null) //obje görünmez olduðunda objeyi geri yolla
        {
            objectPool.ReturnToPool(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) //objeye ateþ ettiðimizde görünmeze yapýyoruz ve sýraya geri dönüyor
    {
        if (collision.gameObject.tag == "Bullet")
        {
            gameObject.SetActive(false);
        }
    }
}
