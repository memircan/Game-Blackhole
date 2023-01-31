using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;


    // Start is called before the first frame update
    void Start()
    {
        DestroyMe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void DestroyMe()
    {
        Destroy(gameObject, 5f);
    }

    public void OnTriggerEnter2D(Collider2D collision) //objeye ate� etti�imizde g�r�nmeze yap�yoruz ve s�raya geri d�n�yor
    {
        if (collision.gameObject.tag == "Rock")
        {
            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            collision.gameObject.SetActive(false);
        }
    }

}
