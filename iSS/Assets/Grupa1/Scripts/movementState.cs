using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : MonoBehaviour
{
    public MonoBehaviour shootingState;

    private CharacterController controller;
    [SerializeField] private float playerSpeed = 100.0f;
    private Animator animator;
    private Camera FPcamera;
    private Camera TPcamera;

    private AudioSource walkingSound;

    [SerializeField] private ViewRotation fpcScript;
    [SerializeField] private ViewRotation tpcScript;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        FPcamera = GetComponentInChildren<Camera>();
        TPcamera = transform.Find("ThirdPersonCamera").GetComponent<Camera>();

        walkingSound = GetComponent<AudioSource>();

        TPcamera.enabled = true;
        FPcamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = HandleMovementInputs();

        controller.SimpleMove(direction * playerSpeed);

        HandleMovementStateInputs();
        HandleMovementSounds(direction);
    }
    
    // Upravlja kretanjem
    private Vector3 HandleMovementInputs()
    {
        Vector3 moveDirForward = transform.forward * Input.GetAxis("Vertical");
        Vector3 moveDirSide = transform.right * Input.GetAxis("Horizontal");

        Vector3 direction = moveDirForward + moveDirSide;
        if (direction.magnitude > 1)
            direction = direction.normalized;
        return direction;
    }

    // Upravlja animacijama i promjenama stanja
    private void HandleMovementStateInputs()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            animator.SetBool("isWalkingForward", true);
        //if (Input.GetKeyUp(KeyCode.W))
        if (Input.GetKeyUp(KeyCode.UpArrow))
            animator.SetBool("isWalkingForward", false);
        //if (Input.GetKeyDown(KeyCode.S))
        if (Input.GetKeyDown(KeyCode.DownArrow))
            animator.SetBool("isWalkingBackward", true);
        //if (Input.GetKeyUp(KeyCode.S))
        if (Input.GetKeyUp(KeyCode.DownArrow))
            animator.SetBool("isWalkingBackward", false);
        //if (Input.GetKeyDown(KeyCode.A))
          if (Input.GetKeyDown(KeyCode.LeftArrow))
            animator.SetBool("isWalkingLeft", true);
        //if (Input.GetKeyUp(KeyCode.A))
        if (Input.GetKeyUp(KeyCode.LeftArrow))
            animator.SetBool("isWalkingLeft", false);
        //if (Input.GetKeyDown(KeyCode.D))
        if (Input.GetKeyDown(KeyCode.RightArrow))
            animator.SetBool("isWalkingRight", true);
        //if (Input.GetKeyUp(KeyCode.D))
        if (Input.GetKeyUp(KeyCode.RightArrow))
            animator.SetBool("isWalkingRight", false);

        if (Input.GetMouseButtonDown(1))
        {
            shootingState.enabled = true;
            enabled = false;
            walkingSound.Stop();
            animator.SetBool("isWalkingForward", false);
            animator.SetBool("isWalkingBackward", false);
            animator.SetBool("isWalkingLeft", false);
            animator.SetBool("isWalkingRight", false);
            animator.SetBool("isAiming", true);

            FPcamera.GetComponent<ViewRotation>().mouseSensitivity = 0.4f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<DeathState>().enabled = true;
            enabled = false;
        }
    }

    // Upravlja zvukovima hodanja
    private void HandleMovementSounds(Vector3 direction)
    {
        if (direction.magnitude != 0 && !walkingSound.isPlaying && enabled)
            walkingSound.Play();
        else if ((direction.magnitude == 0 && walkingSound.isPlaying) || !enabled)
            walkingSound.Stop();
    }
}
