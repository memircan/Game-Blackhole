using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class ReturnToPoolBullet : MonoBehaviour
{
    [SerializeField]
    GameObject explosionPrefab;
    Animation _anim;   
    
    BulletPool bulletPool;

    public void Start()
    {
        bulletPool = FindObjectOfType<BulletPool>();
        Animation _anim = explosionPrefab.GetComponent<Animation>();
        
    }

    void OnEnable()
    {
        
        StartCoroutine(ReturnPool());
        //Invoke("ReturnPool", 3f);
    }

    public IEnumerator ReturnPool()
    {
        yield return new WaitForSeconds(3f);
        bulletPool.ReturnBullet(this.gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision) //if bullet hit rock, add the bullet in que and setactiive false
    {
        if (collision.gameObject.tag == "Rock")
        {
            //GameObject exp = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            //Destroy(exp, 2f); //destroy exp prefab after 2f sec.


            //explosionPrefab.transform.position = gameObject.transform.position;
            //explosionPrefab.SetActive(true);
            //_anim.Play();
            
            bulletPool.ReturnBullet(this.gameObject);
            collision.gameObject.SetActive(false);
        }
    }


   
}
