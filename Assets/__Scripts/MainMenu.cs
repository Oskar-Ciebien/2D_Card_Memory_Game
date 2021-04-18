using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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

    private void SetSoundsState()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }

}
