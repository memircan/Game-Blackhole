using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMove : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(new Vector2(-(rb.velocity.x+5), 0));
        rb.velocity = new Vector2(-5, 0);
        rb.AddTorque(0.1f);
    }

}
