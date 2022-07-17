using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementt : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    private bool jump = false;
    private bool crouch = false;


    private void Update()
    {
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove* Time.fixedDeltaTime, false, jump); //if you want to use crouch, change it to crouch = crouch
        jump = false;
    }
}
