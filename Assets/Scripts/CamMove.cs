using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    
    float speed;
    float acceleretion;
    float topSpeed;
    bool move;


    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
        acceleretion = 0.05f;
        topSpeed = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        cameraMove();

        transform.GetChild(0).transform.Rotate(0f, 0f, 30f* Time.deltaTime); //blackhole rotate

    }

    void cameraMove()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        speed += acceleretion * Time.deltaTime; 

        if(speed> topSpeed )
        {
            speed = topSpeed;            
        }
    }
}
