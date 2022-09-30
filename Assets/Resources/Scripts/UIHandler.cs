using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    private bool isPaused = true;
    [SerializeField] private GameObject pauseOverlay;
    [SerializeField] private GameObject WinOverlay;

    void Start()
    {
        //Starts the game paused
        Time.timeScale = 0;
    }

    //Toggles pause/resume in the game
    public void TogglePauseGame()
    {
        if (isPaused)
        {
            //Resumes the game
            Time.timeScale = 1;
            //Disable the pause UI overlay in the screen
            pauseOverlay.SetActive(false);
            //Updates the bool value
            isPaused = false;
        }
        else
        {
            //Pauses the game
            Time.timeScale = 0;
            //Shows the pause UI overlay in the screen
            pauseOverlay.SetActive(true);
            //Updates the bool value
            isPaused = true;
        }
    }

    //Triggers the level finish description
    public void FinishLevelTrigger()
    {
        //Pauses the game
        Time.timeScale = 0;
        //Hides the pause layout if it is being shown
        pauseOverlay.SetActive(false);
        //Update the bool value
        isPaused = true;
        //Shows the win layout
        WinOverlay.SetActive(true);
    }
}
