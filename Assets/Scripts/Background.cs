using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    float bgLocation;
    float distance= 38.402f;


    // Start is called before the first frame update
    void Start()
    {
        bgLocation = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(bgLocation + distance < Camera.main.transform.position.x)
        {
            CopyBg();          
        }   
    }
    
    void CopyBg()
    {
        bgLocation += (distance * 2);
        Vector2 newPos = new Vector2(bgLocation, 0);
        transform.position=newPos;
    }

}
