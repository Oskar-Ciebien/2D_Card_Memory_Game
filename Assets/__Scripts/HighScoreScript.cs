﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
    public GameObject score;
    public GameObject scoreName;
    public GameObject rank;

    public void SetScore(string name, string score, string rank)
    {       
        this.rank.GetComponent<Text>().text = rank;
        this.scoreName.GetComponent<Text>().text = name;
        this.score.GetComponent<Text>().text = score;
    }
}
