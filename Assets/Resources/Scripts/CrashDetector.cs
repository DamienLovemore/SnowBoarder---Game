using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float crashDelay;
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private AudioClip crashSFX;
    private PlayerController playerControl;

    void Start()
    {
        //Gets the first component of this type in the whole game
        //(not just within this game object)
        playerControl = FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Terrain")
        {
            //It the player has crashed it can no longer move
            playerControl.DisableControls();
            crashEffect.Play();
            //Used to play different audio clips with the same AudioSource
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
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
