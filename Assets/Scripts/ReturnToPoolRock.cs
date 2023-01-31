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
        if (objectPool != null) //obje g�r�nmez oldu�unda objeyi geri yolla
        {
            objectPool.ReturnToPool(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) //objeye ate� etti�imizde g�r�nmeze yap�yoruz ve s�raya geri d�n�yor
    {
        if (collision.gameObject.tag == "Bullet")
        {
            gameObject.SetActive(false);
        }
    }
}
