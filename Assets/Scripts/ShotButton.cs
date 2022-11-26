using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShotButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public bool keyDown;

    public void OnPointerDown(PointerEventData eventData)
    {
        keyDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        keyDown = false;
    }
}
