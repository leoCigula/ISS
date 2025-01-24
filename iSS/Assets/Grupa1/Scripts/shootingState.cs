using System.Collections;
using UnityEngine;

public class ShootingState : MonoBehaviour
{
    [SerializeField] private MonoBehaviour movementState;
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform spawnPoint;
    private Animator animator;
    private GameObject rocket=null;
    private float lastTimeFiredTime = 0f;
    [SerializeField] private float reloadTime = 0f;

    [SerializeField] private ViewRotation fpcScript;
    [SerializeField] private ViewRotation tpcScript;

    [SerializeField] private AudioSource rocketLaunchSound;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        lastTimeFiredTime = 0f;
        reloadTime = 0f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= lastTimeFiredTime + reloadTime)
        {
            rocket = Instantiate(rocketPrefab, spawnPoint.position, transform.rotation);
            Rocket rocketScript = rocket.GetComponent<Rocket>();
            rocketScript.SetCameraTransform(playerCamera);
            lastTimeFiredTime = Time.time;
            reloadTime = 4f;

            StartCoroutine(StartRecoil());
        }

        if (Input.GetMouseButtonDown(1))
        {
            movementState.enabled = true;
            enabled = false;
            animator.SetBool("isAiming", false);
        }

        // if (Input.GetKeyDown("space"))
        // {
        //     GetComponent<deathState>().enabled = true;
        // }
    }

    IEnumerator StartRecoil()
    {
        rocketLaunchSound.Play();
        animator.Play("gun_fire");
        yield return new WaitForSeconds(0.6f);
        animator.CrossFade("gun_aim_idle", 0.2f);
    }
}
