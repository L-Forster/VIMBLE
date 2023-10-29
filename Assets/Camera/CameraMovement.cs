using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 cameraPosition;
    
    [Header("Camera Settings")]
    public float cameraSpeed = 5.0f; // Adjust the speed in the Inspector.

    void Start()
    {
        cameraPosition = transform.position;
    }

    void Update()
    {
        // Store the current position of the camera
        Vector3 currentPosition = transform.position;
        // Check for input and update the camera's position
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            cameraSpeed =  cameraSpeed*3;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            cameraSpeed = cameraSpeed/3;
        }
        if (Input.GetKey(KeyCode.W))
        {
            currentPosition += Vector3.up * cameraSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentPosition += Vector3.down * cameraSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            currentPosition += Vector3.left * cameraSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentPosition += Vector3.right * cameraSpeed * Time.deltaTime;
        }

        // Apply the new position to the camera
        transform.position = currentPosition;
    }
}
