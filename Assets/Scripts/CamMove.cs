using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{

    float speed = 2f;
    float acceleretion = 0.05f;
    float topSpeed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {

        //blackhole optimization for all screen size
        transform.GetChild(0).transform.position = new Vector3(-ScreenCalculator.instance.Width, 0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        cameraMove();

        transform.GetChild(0).transform.Rotate(0f, 0f, 30f * Time.deltaTime); //blackhole rotate

    }

    void cameraMove()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        speed += acceleretion * Time.deltaTime;

        if (speed > topSpeed)
        {
            speed = topSpeed;
        }
    }
}
