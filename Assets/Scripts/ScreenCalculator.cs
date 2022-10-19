using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCalculator : MonoBehaviour
{
    public static ScreenCalculator instance;

    float height;
    float width;



    public float Height
    {
        get
        {
            return height;
        }
    }

    public float Width
    {
        get
        {
            return width;
        }
    }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
    }


}
