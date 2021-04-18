using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Variables
    public GameObject soundsOn;
    public GameObject soundsOff;

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

    // Sound code adapted from - https://www.youtube.com/watch?v=ABqmWhD5Ny8&ab_channel=Rabidgremlin

    // ToggleSound - Toggles the in-game sounds
    public void ToggleSound()
    {
        // If the muted value is currently set to 0
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            // Set the value to 1
            PlayerPrefs.SetInt("Muted", 1);
        }
        // If the value is already set to 1
        else
        {
            // Set the value to 0
            PlayerPrefs.SetInt("Muted", 0);
        }

        // Calling SetSoundsState method
        SetSoundsState();
    } // ToggleSound - END

    // SetSoundsState - Sets the volume of the game
    private void SetSoundsState()
    {
        // If the sounds are muted
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            // Turn the sounds on
            AudioListener.volume = 1;
        }
        // If the sounds are on
        else
        {
            // Turn the sounds off
            AudioListener.volume = 0;
        }
    }

}
