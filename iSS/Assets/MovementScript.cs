using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)){
            rigidBody.velocity = Vector3.forward * 10;

        }
        if (Input.GetKeyDown(KeyCode.S)){
            rigidBody.velocity = -Vector3.forward * 10;

        }
    }
}
