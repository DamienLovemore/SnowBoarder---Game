using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float crashDelay;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Terrain")
        {
            Invoke("ReloadScene", crashDelay);
        }
    }

    //Reset the level for the player to start from
    //the beggining (game over)
    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
