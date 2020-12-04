using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /*
     
     * I DID NOT MAKE THIS PLAYER MOVEMENT
     * I wanted to focus on my own mechanic, 
     * so I found a quick guide on FPS movement, 
     * so I could implement my looting system. 
     * Everything in this script is from a tutorial
     * Everything else is my own. :)
     
    */


    public CharacterController controller;
    public Transform groundCheck;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0) {
            velocity.y = -2;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
  
    }
}
