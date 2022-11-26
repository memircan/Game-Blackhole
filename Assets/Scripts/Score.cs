using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    int score;

    // Update is called once per frame
    void Update()
    {
        score = (int)Camera.main.transform.position.x;
        scoreText.text = "Score: " + score;
    }
}
