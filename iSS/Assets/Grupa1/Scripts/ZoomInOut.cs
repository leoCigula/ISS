using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInOut : MonoBehaviour
{
    private Camera myCamera;
    private float[] zoomLevels = { 5f, 10f, 15f, 25f };
    private float targetFOV;

    private void Start()
    {
        myCamera = GetComponent<Camera>();
        myCamera.fieldOfView = 25;
        targetFOV = myCamera.fieldOfView;
    }

    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0f)
        {
            if (scrollInput < 0f)
            {
                targetFOV = Mathf.Min(targetFOV + 5, zoomLevels[3]);
            }
            else if (scrollInput > 0f)
            {
                targetFOV = Mathf.Max(targetFOV - 5, zoomLevels[0]);
            }

        }
        myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, targetFOV, Time.deltaTime * 35);

    }
}