using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        col.transform.parent = gameObject.transform;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        col.transform.parent = null;
    }
}
