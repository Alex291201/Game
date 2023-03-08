using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    bool jump = false;
    float horizontalMove = 0f;
    // Update is called once per frame
    void Update()
    {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
       animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
       if (Input.GetButtonDown("Jump"))
       {
           jump = true;
           animator.SetBool("Jumping", jump);
       }

       
    }
    public void OnLanding()
    {
        animator.SetBool("Jumping", false);
    }
    void FixedUpdate ()
    {
        // Move character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false , jump);
        
        jump = false;
    }
}
