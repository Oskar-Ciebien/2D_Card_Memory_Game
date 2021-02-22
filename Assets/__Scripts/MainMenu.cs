using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Play - Starts the game, putting the player to level 1
    public void Play()
    {
        SceneManager.LoadScene("Level_1");
    } // Play - END
    
    // Exit - Exits the game
    public void Exit()
    {
        Application.Quit();
    } // Exit - END
}
