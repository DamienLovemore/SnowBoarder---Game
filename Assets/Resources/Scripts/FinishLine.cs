using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float finishDelay;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("FinishLevel", finishDelay);
        }
    }

    //Display a message saying that the player has won
    private void FinishLevel()
    {
        SceneManager.LoadScene(0);
    }
}
