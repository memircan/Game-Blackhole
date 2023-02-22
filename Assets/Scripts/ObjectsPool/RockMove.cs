using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMove : MonoBehaviour
{
    Rigidbody2D rb;


    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        rb.velocity = -transform.right * 5f;       
    }
}
