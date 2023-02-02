using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ReturnToPoolBullet : MonoBehaviour 
{
    [SerializeField]
    private GameObject explosionPrefab;

    BulletPool bulletPool;

    
    void Start()
    {
        bulletPool = FindObjectOfType<BulletPool>();       
    }

    private void OnEnable()
    {
        StartCoroutine(ReturnPool());      
    }

    public IEnumerator ReturnPool()
    {          
        yield return new WaitForSeconds(3f);
        bulletPool.ReturnBullet(this.gameObject); 
    }


    public void OnTriggerEnter2D(Collider2D collision) //objeye ate� etti�imizde g�r�nmez yap�yoruz ve s�raya geri d�n�yor
    {
        if (collision.gameObject.tag == "Rock")
        {
            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            bulletPool.ReturnBullet(this.gameObject);
            collision.gameObject.SetActive(false);
        }
    }

}
