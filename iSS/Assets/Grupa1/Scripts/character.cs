using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class character : MonoBehaviour
{

    public Transform player;
    public float mouseSensitivity = 2f;
    float cameraVerticalRotation = 0f;
    public GameObject rocketLauncher;

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

        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 30f);

        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        player.transform.Rotate(Vector3.up * inputX);
    }
}
