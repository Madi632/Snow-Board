using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] AudioClip boostSFX;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
        
    }

    public void DisableControls() 
    {
        canMove = false;
    }

    void RespondToBoost()
    {
        // If we push up, then speed up
        // Otherwise stay at normal speed

        if(Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
            GetComponent<AudioSource>().PlayOneShot(boostSFX);
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }

    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
