using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExp : MonoBehaviour
{
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
        Destroy(gameObject, 2f);
    }
}
