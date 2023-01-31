using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReturnToPoolRock : MonoBehaviour
{
    private ObjectPool objectPool;    

    public void Start()
    {
        objectPool=FindObjectOfType<ObjectPool>();   
    }

    void OnDisable()
    {
        if (objectPool != null) //obje görünmez olduðunda objeyi geri yolla
        {
            objectPool.ReturnToPool(this.gameObject);
        }
    }

    
}
