using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer  spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 tempScale = transform.localScale;

        float spriteWidth = spriteRenderer.size.x;
        float screenHeight = Camera.main.orthographicSize * 2f;
        float screenWidth = screenHeight / Screen.height * Screen.width;

        tempScale.x = screenWidth / spriteWidth;
        transform.localScale = tempScale;
    }
    
}
