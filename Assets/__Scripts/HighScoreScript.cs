using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
    public GameObject rank;
    public GameObject scoreName;
    public GameObject score;
   
    

    public void SetScore(string rank, string name, string score)
    {
        this.rank.GetComponent<Text>().text = rank;
        this.scoreName.GetComponent<Text>().text = name;
        this.score.GetComponent<Text>().text = score;
                
    }
}
