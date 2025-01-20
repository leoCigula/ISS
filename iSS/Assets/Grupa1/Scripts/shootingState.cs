using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingState : MonoBehaviour
{
    [SerializeField] private MonoBehaviour movementState;
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform spawnPoint;
    private Animator animator;
    private GameObject rocket=null;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && rocket==null)
        {
            rocket = Instantiate(rocketPrefab, spawnPoint.position, transform.rotation);
            Rocket rocketScript = rocket.GetComponent<Rocket>();
            rocketScript.SetCameraTransform(playerCamera);
        }

        if (Input.GetMouseButtonDown(1))
        {
            movementState.enabled = true;
            enabled = false;
            animator.SetBool("isAiming", false);
        }
    }


}
