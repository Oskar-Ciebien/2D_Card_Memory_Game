using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    // PlayEasy - Starts the game on Easy Level
    public void PlayEasy()
    {
        SceneManager.LoadScene("Level_Easy");
    } // PlayEasy - END

    // PlayMedium - Starts the game on Medium Level
    public void PlayMedium()
    {
        SceneManager.LoadScene("Level_Medium");
    } // PlayMedium - END

    // PlayHard - Starts the game on Hard Level
    public void PlayHard()
    {
        SceneManager.LoadScene("Level_Hard");
    } // PlayHard - END

    // GoBack - Returns to the Main Menu
    public void GoBack()
    {
        SceneManager.LoadScene("Main_Menu");
    } // GoBack - END
}
