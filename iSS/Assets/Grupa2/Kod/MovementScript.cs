using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Rigidbody rigidBody;       
    public float moveSpeed = 5f;      
    public float rotateSpeed = 10f;  
    public float accelerationRate = 5f;  
    public float decelerationRate = 5f;  

    private Vector3 currentVelocity;  
    private float rotationInput = 0f; 

    void Update()
    {
       
        if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))) 
        {
            rotationInput = -1f; 
        }
        else if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))) 
        {
            rotationInput = 1f; 
        }
        else
        {
            rotationInput = 0f; 
        }
    }

    void FixedUpdate()
    {
        
        float forwardInput = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            forwardInput = 1f; 
        }
        else if (Input.GetKey(KeyCode.S))
        {
            forwardInput = -1f; 
        }

        
        Vector3 targetVelocity = transform.forward * forwardInput * moveSpeed;

        
        if (forwardInput != 0)
        {
           
            currentVelocity = Vector3.MoveTowards(
                currentVelocity,
                targetVelocity,
                accelerationRate * Time.fixedDeltaTime
            );
        }
        else
        {
            
            currentVelocity = Vector3.MoveTowards(
                currentVelocity,
                Vector3.zero,
                decelerationRate * Time.fixedDeltaTime
            );
        }

        
        rigidBody.velocity = currentVelocity;

       
        if (rotationInput != 0f)
        {
            
            float rotationAmount = rotationInput * rotateSpeed * Time.fixedDeltaTime;
            transform.Rotate(0f, rotationAmount, 0f);
        }
    }
}
