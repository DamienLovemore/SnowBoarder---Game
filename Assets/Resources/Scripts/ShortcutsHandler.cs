using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutsHandler : MonoBehaviour
{
    private UIHandler uiManager;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        //Pause/Unpause the game
        if(Input.GetKeyDown(KeyCode.Return))
            uiManager.TogglePauseGame();
        //Closes the game
        else if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        //Toggles between fullscreen/windowed screen mode
        else if (Input.GetKeyDown(KeyCode.F11))
            ToggleFullscreen();
    }

    //Toggle between fullscreen mode and windowed mode
    private void ToggleFullscreen()
    {
        FullScreenMode actualScreenMode = Screen.fullScreenMode;

        //If is in windowed mode then switches to Fullscreen
        if ((actualScreenMode == FullScreenMode.Windowed) || (actualScreenMode == FullScreenMode.MaximizedWindow))
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        //If it is in fullscreen mode then switches to windowed mode
        else
            Screen.fullScreenMode = FullScreenMode.Windowed;
    }
}
