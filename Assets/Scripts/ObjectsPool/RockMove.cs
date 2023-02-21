using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMove : MonoBehaviour
{
    void Update()
    {
        transform.Translate(-transform.right * 0.01f);       
    }
}
