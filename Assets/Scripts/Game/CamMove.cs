using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    [SerializeField]
    GameObject blachole;

    float speed = 2f;
    float acceleretion = 0.05f;
    float topSpeed = 3.5f;

    void Start()
    {
        //blackhole optimization for all screen size
        blachole.transform.position = new Vector3(-ScreenCalculator.instance.Width, 0, -1);      
    }

    void Update()
    {        
        cameraMove();
    }

    void cameraMove()
    {        
        speed += acceleretion * Time.deltaTime;
        speed = Mathf.Min(speed, topSpeed);
        transform.position += transform.right * speed * Time.deltaTime;
        
    }
}
