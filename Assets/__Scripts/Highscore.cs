using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
    
    

    public Highscore (int id, string name, int score)
    {
        this.Score = score;
        this.Name = name;
        this.ID = id;
    }
}

