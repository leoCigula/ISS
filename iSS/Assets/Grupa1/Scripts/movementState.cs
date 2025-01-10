using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementState : MonoBehaviour
{
    public MonoBehaviour shootingState;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 moveDirForward = transform.forward * Input.GetAxis("Vertical");
        Vector3 moveDirSide = transform.right * Input.GetAxis("Horizontal");

        Vector3 direction = moveDirForward + moveDirSide;
        if(direction.magnitude > 1)
            direction = direction.normalized;
        
        
        controller.SimpleMove(direction * playerSpeed);


        if (Input.GetMouseButtonDown(1))
        {
            shootingState.enabled = true;
            enabled = false;
        }


    }
}
