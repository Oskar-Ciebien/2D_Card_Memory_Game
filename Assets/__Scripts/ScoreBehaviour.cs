using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehaviour : MonoBehaviour
{
    // Variables
    public Text scoreText;
    public float scoreAmt;

    // Start
    void Start()
    {
        // Score Amount
        scoreAmt = 0f;
    } // Start - END

    // Update
    void Update()
    {
        // Increase the score text by 1 every second 
        scoreText.text = "Score - " + (int)scoreAmt;
        scoreAmt += 1 * Time.deltaTime;
    } // Update - END
}
