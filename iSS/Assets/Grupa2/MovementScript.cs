using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MovementScript : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float moveSpeed = 5;
    public float rotateSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ( rigidBody)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Vector3 targetPosition = transform.position + (transform.forward * moveSpeed * Time.deltaTime);
                rigidBody.MovePosition(targetPosition);

            }
            if (Input.GetKey(KeyCode.S))
            {
                Vector3 targetPosition = transform.position - (transform.forward * moveSpeed * Time.deltaTime);
                rigidBody.MovePosition(targetPosition);

            }
            if (Input.GetKey(KeyCode.A)) { 

                if ( !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
                {
                    Quaternion targetRotation = transform.rotation * (Quaternion.Euler(new Vector3(0, -rotateSpeed, 0)));
                    rigidBody.MoveRotation(targetRotation);
                }
                else
                {
                    Quaternion targetRotation = transform.rotation * (Quaternion.Euler(new Vector3(0, -rotateSpeed * 0.5f, 0)));
                    rigidBody.MoveRotation(targetRotation);
                }
            
               

            }
            if (Input.GetKey(KeyCode.D) )
            {
                if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
                {
                    Quaternion targetRotation = transform.rotation * (Quaternion.Euler(new Vector3(0, rotateSpeed, 0)));
                    rigidBody.MoveRotation(targetRotation);
                }
                else
                {
                    Quaternion targetRotation = transform.rotation * (Quaternion.Euler(new Vector3(0, rotateSpeed * 0.5f, 0)));
                    rigidBody.MoveRotation(targetRotation);
                }


            }


        }













   
    }
}
