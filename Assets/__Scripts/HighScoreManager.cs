using System.Collections;
using System.Collections.Generic;
using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    private string connectionString;

    private List<Highscore> highscores = new List<Highscore>();

    public GameObject scorePrefab;

    public Transform scoreParent;

    // Start is called before the first frame update
    void Start()
    {
        connectionString = "URI=file:" + Application.dataPath + "/HighscoreDB.db";
        //InsertScore("mandy", 29);
        //GetScores();
        ShowScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //adding scores to database
    private void InsertScore(string name, int newScore)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("INSERT INTO highscore(name,score) VALUES(\"{0}\", \"{1}\")", name, newScore);

                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();

            }
        }
    }

    //return database test
    private void GetScores()
    {
        //clear list
        highscores.Clear();

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM highscore";

                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        highscores.Add(new Highscore(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                    }

                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
    }

    private void ShowScores()
    {
        GetScores();

        for (int i = 0; i < highscores.Count; i++)
        {
            GameObject tmpObjec = Instantiate(scorePrefab);

            Highscore tmpScore = highscores[i];

            tmpObjec.GetComponent<HighScoreScript>().SetScore(tmpScore.Name, tmpScore.Score.ToString(), "a" + (i + 1).ToString());

            tmpObjec.transform.SetParent(scoreParent);
        }
    }
}
