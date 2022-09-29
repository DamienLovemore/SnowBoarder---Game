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
    private bool hasCrashed = false;

    void Start()
    {
        //Gets the first component of this type in the whole game
        //(not just within this game object)
        playerControl = FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Use a boolean variable so the crash triggered is played once,
        //even if the player bounces twice before dying
        if ((collision.tag == "Terrain") && (!hasCrashed))
        {
            //It the player has crashed it can no longer move
            playerControl.DisableControls();
            crashEffect.Play();
            //Used to play different audio clips with the same AudioSource
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", crashDelay);
            hasCrashed = true;
        }
    }

    //Reset the level for the player to start from
    //the beggining (game over)
    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
