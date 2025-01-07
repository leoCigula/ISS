using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementState : MonoBehaviour
{
    public MonoBehaviour shootingState;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 100.0f;
    private float gravityValue = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        move = transform.forward * move.z + transform.right * move.x;


        controller.Move(Vector3.Normalize(move) * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            //gameObject.transform.position += move; // ne znam jel potrebno
        }
        //playerVelocity.y += gravityValue * Time.deltaTime;



        if (Input.GetMouseButtonDown(0))
        {
            shootingState.enabled = true;
            enabled = false;
        }


    }
}
