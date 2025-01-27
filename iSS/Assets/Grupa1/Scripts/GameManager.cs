using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField] private ZoomInOut zoomInOutScript;

    [SerializeField] private GameObject pauseScreen;
    public bool isPaused;
    public bool isOver;

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
        }
        pauseScreen.SetActive(false);
        isPaused = false;
        isOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused && !isOver)
        {
            if (shootingState.enabled)
            {
                aimCanvas.SetActive(true);

                cc.height = 12;
                cc.center = new Vector3(cc.center.x, -10, cc.center.z);

                zoomInOutScript.enabled = true;

                SwitchViewState();
            }
            else if (movementState.enabled)
            {
                aimCanvas.SetActive(false);

                cc.height = 16.9f;
                cc.center = new Vector3(cc.center.x, -7.37f, cc.center.z);

                zoomInOutScript.enabled = false;

                if (Input.GetKeyDown(KeyCode.Q))
                    isFirstPersonCamera = !isFirstPersonCamera;

                SwitchViewState();
            }
            else if (deathState.enabled)
            {
                aimCanvas.SetActive(false);

                SwitchViewState();
            }

            ChangeFPCamFOV();
        }
        MenuControls();
    }

    // Mijenja stanje i kameru kojom se upravlja
    private void SwitchViewState()
    {
        if (isPaused) return;
        TPcamera.enabled = movementState.enabled | deathState.enabled;
        tpcScript.enabled = !deathState.enabled && !isFirstPersonCamera && !shootingState.enabled;
        TPcamera.enabled = deathState.enabled || !isFirstPersonCamera;
        FPcamera.enabled = shootingState.enabled | (movementState.enabled && isFirstPersonCamera);
        fpcScript.enabled = shootingState.enabled | (movementState.enabled && isFirstPersonCamera);
    }

    // Mijenja FOV kamere za First person perspektivu
    private void ChangeFPCamFOV()
    {
        if (isFirstPersonCamera && movementState.enabled && !shootingState.enabled)
            FPcamera.fieldOfView = 80;
    }

    // Kontrole za main menu
    private void MenuControls() 
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Cursor.lockState = CursorLockMode.None;
            pauseScreen.SetActive(isPaused);
        }
        Cursor.visible = isPaused || isOver;
        Time.timeScale = isPaused? 0 : 1;
        AudioListener.volume = isPaused? 0 : 1;
        tpcScript.enabled = !isPaused && !isOver;
        fpcScript.enabled = !isPaused && !isOver;
    }
}
