using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;

public class ViewRotation : MonoBehaviour
{

    public Transform player;
    public float mouseSensitivity = 1.5f;
    float cameraVerticalRotation = 0f;
    float torsoVerticalRotation = 0f;
    public Transform torso;
    public Transform eyes;
    [SerializeField] private ShootingState ss;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        if(name == "Camera" && !ss.enabled) 
        {
            torsoVerticalRotation -= inputY;
            torsoVerticalRotation = Mathf.Clamp(torsoVerticalRotation, -65f, 20f);
            transform.localPosition = new Vector3(0f, eyes.transform.position.y - 17, 0.69f);
            cameraVerticalRotation -= inputY;
            cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -65f, 20f);
            transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
        }
        else if (name == "Camera" && ss.enabled)
        {
            torsoVerticalRotation -= inputY;
            torsoVerticalRotation = Mathf.Clamp(torsoVerticalRotation, -65f, 20f);
            transform.position = new Vector3(eyes.transform.position.x, eyes.transform.position.y, eyes.transform.position.z);
            transform.eulerAngles = new Vector3(eyes.eulerAngles.x, eyes.eulerAngles.y, 0);
        }
        else if (name == "ThirdPersonCamera" && CompareTag("MainCamera"))
        {
            cameraVerticalRotation -= inputY;
            cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -65f, 20f);
            transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
        }

        player.transform.Rotate(Vector3.up * inputX);

    }

    void LateUpdate()
    {
        torso.localEulerAngles += new Vector3(1f, 0, 0) * torsoVerticalRotation;
    }
}
