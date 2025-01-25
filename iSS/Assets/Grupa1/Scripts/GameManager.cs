using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    private CharacterController cc;
    private MovementState movementState;
    private ShootingState shootingState;
    private DeathState deathState;
    [SerializeField] private GameObject aimCanvas;

    [SerializeField] private Camera FPcamera;
    [SerializeField] private Camera TPcamera;
    [SerializeField] private ViewRotation fpcScript;
    [SerializeField] private ViewRotation tpcScript;

    private bool isFirstPersonCamera = true;
    // Start is called before the first frame update
    void Start()
    {
        if(aimCanvas)
            aimCanvas.SetActive(false);
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            movementState = player.GetComponent<MovementState>();
            shootingState = player.GetComponent<ShootingState>();
            deathState = player.GetComponent<DeathState>();
            cc = player.GetComponent<CharacterController>();
            Debug.Log(cc.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shootingState.enabled)
        {
            aimCanvas.SetActive(true);

            cc.height = 12;
            cc.center = new Vector3(cc.center.x, -10, cc.center.z);

            SwitchViewState();
        }
        else if (movementState.enabled)
        {
            aimCanvas.SetActive(false);

            cc.height = 16.9f;
            cc.center = new Vector3(cc.center.x, -7.37f, cc.center.z);

            SwitchViewState();
        }
        else if (deathState.enabled)
        {
            aimCanvas.SetActive(false);

            SwitchViewState();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            isFirstPersonCamera = !isFirstPersonCamera;
        }

        ChangeFPCamFOV();
    }

    // Mijenja stanje i kameru kojom se upravlja
    private void SwitchViewState()
    {
        // TPcamera.enabled = movementState.enabled | deathState.enabled;
        tpcScript.enabled = !isFirstPersonCamera;
        TPcamera.enabled = deathState.enabled || !isFirstPersonCamera;
        FPcamera.enabled = shootingState.enabled | (movementState.enabled && isFirstPersonCamera);
        fpcScript.enabled = shootingState.enabled | (movementState.enabled && isFirstPersonCamera);
    }

    // Mijenja FOV kamere za First person perspektivu
    private void ChangeFPCamFOV()
    {
        if (isFirstPersonCamera && movementState.enabled)
            FPcamera.fieldOfView = 60;
        else
            FPcamera.fieldOfView = 45;
    }
}
