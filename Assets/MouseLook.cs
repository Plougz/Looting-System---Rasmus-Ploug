using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    /*
     
     * I DID NOT MAKE THIS PLAYER MOVEMENT
     * I wanted to focus on my own mechanic, 
     * so I found a quick guide on FPS movement, 
     * so I could implement my looting system. 
     * Everything in this script is from a tutorial
     * Everything else is my own. :)
     
    */

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
       
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        playerBody.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
    }
}
