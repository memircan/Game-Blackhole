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
    

    public void OnTriggerEnter2D(Collider2D collision) //if bullet hit rock, add the bullet in que and setactiive false
    {
        if (collision.gameObject.tag == "Rock")
        {
            GameObject exp = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(exp, 2f); //destroy exp prefab after 2f sec.
            bulletPool.ReturnBullet(this.gameObject);
            collision.gameObject.SetActive(false);
        }
    }

   
}
