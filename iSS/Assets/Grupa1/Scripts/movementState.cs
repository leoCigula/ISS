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

    public AudioSource walkingSound;

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

        Vector3 moveDirForward = transform.forward * Input.GetAxis("Vertical");
        Vector3 moveDirSide = transform.right * Input.GetAxis("Horizontal");

        Vector3 direction = moveDirForward + moveDirSide;
        if (direction.magnitude > 1)
            direction = direction.normalized;
        
        if (direction.magnitude != 0 && !walkingSound.isPlaying)
        {
            walkingSound.Play();
        }
        else if (direction.magnitude == 0 && walkingSound.isPlaying)
        {
            walkingSound.Stop();
        }

        if (Input.GetKeyDown(KeyCode.W))
            animator.SetBool("isWalkingForward", true);
        if (Input.GetKeyUp(KeyCode.W))
            animator.SetBool("isWalkingForward", false);
        if (Input.GetKeyDown(KeyCode.S))
            animator.SetBool("isWalkingBackward", true);
        if (Input.GetKeyUp(KeyCode.S))
            animator.SetBool("isWalkingBackward", false);
        if (Input.GetKeyDown(KeyCode.A))
            animator.SetBool("isWalkingLeft", true);
        if (Input.GetKeyUp(KeyCode.A))
            animator.SetBool("isWalkingLeft", false);
        if (Input.GetKeyDown(KeyCode.D))
            animator.SetBool("isWalkingRight", true);
        if (Input.GetKeyUp(KeyCode.D))
            animator.SetBool("isWalkingRight", false);

        controller.SimpleMove(direction * playerSpeed);


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
        }

        // Mijenja kameru ovisno o stanju u kojem se nalazi
        if (enabled)
        {
            TPcamera.enabled = true;
            tpcScript.enabled = true;
            FPcamera.enabled = false;
            fpcScript.enabled = false;
        }
        else
        {
            TPcamera.enabled = false;
            tpcScript.enabled = false;
            FPcamera.enabled = true;
            fpcScript.enabled = true;
        }


        if (Input.GetKeyDown("space"))
        {
            GetComponent<deathState>().enabled = true;
        }
    }

    public void setCamera() //za smrt da se postavi Third person kamera i da bude lockana
    {
        TPcamera.enabled = true;
        tpcScript.enabled = true;
        FPcamera.enabled = false;
        fpcScript.enabled = false;

        transform.Find("ThirdPersonCamera").GetComponent<ViewRotation>().mouseSensitivity = 0;
        walkingSound.Stop();
    }

}
