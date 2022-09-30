using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float finishDelay;
    [SerializeField] ParticleSystem finishEffect;
    private UIHandler uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIHandler>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("FinishLevel", finishDelay);            
        }
    }

    //Display a message saying that the player has won
    private void FinishLevel()
    {
        uiManager.FinishLevelTrigger();
    }
}
