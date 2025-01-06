using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float moveSpeed = 5;
    public float rotateSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)){
             transform.position += (transform.forward * moveSpeed) * Time.deltaTime;
             Debug.Log("stisnuto");

         }
         if (Input.GetKey(KeyCode.S)){
             transform.position += (-transform.forward * moveSpeed) * Time.deltaTime;

         }

        /*if (Input.GetKey(KeyCode.W))
        {
            rigidBody.velocity = (Vector3.forward * moveSpeed) * Time.deltaTime;
            Debug.Log("stisnuto");

        }*/
        if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
        {
            transform.Rotate(new Vector3(0, -rotateSpeed, 0));

        }
        if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
        {
            transform.Rotate(new Vector3(0, rotateSpeed, 0));

        }
    }
}
