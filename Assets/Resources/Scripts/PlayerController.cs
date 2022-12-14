using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float torqueAmount = 1f;
    //The component that controls the physics of the player
    private Rigidbody2D rb2d;
    private SurfaceEffector2D surfaceAcellerator;
    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //Similar to get Component but gets the first component of this
        //type in the whole game, not just within this game object.
        surfaceAcellerator = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }        
    }

    //Disable player movement (if it crashes for example)
    public void DisableControls()
    {
        surfaceAcellerator.speed = 0;
        canMove = false;
    }

    //Increases the speed of the player when is holding the up arrrow
    //Normal speed otherwise
    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceAcellerator.speed = boostSpeed;
        }
        else
        {
            surfaceAcellerator.speed = baseSpeed;
        }
    }

    //Roatates the player left and right
    private void RotatePlayer()
    {
        if ((Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.A)))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if ((Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.D)))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
