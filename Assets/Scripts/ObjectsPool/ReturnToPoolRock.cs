using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReturnToPoolRock : MonoBehaviour
{
    private RockPool objectPool;    

    public void Start()
    {
        objectPool=FindObjectOfType<RockPool>();   
    }

    void OnDisable()
    {
        if (objectPool != null) //obje g�r�nmez oldu�unda objeyi geri yolla
        {
            objectPool.ReturnToPool(this.gameObject);
        }
    }

    
}
