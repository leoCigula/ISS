using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInOut : MonoBehaviour
{
    private Camera myCamera;
    private float[] zoomLevels = { 25f, 15f, 10f, 5f };
    private int currentIndex;
    private float targetFOV;

    private void Start()
    {
        currentIndex = 0;
        myCamera = GetComponent<Camera>();
        myCamera.fieldOfView = 25;
        targetFOV = myCamera.fieldOfView;
    }

    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0f)
        {
            if (scrollInput > 0f)
            {
                currentIndex = Mathf.Min(currentIndex+1, zoomLevels.Length-1);
                targetFOV = zoomLevels[currentIndex];
            }
            else if (scrollInput < 0f)
            {
                currentIndex = Mathf.Max(currentIndex-1, 0);
                targetFOV = zoomLevels[currentIndex];
            }

        }
        myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, targetFOV, Time.deltaTime * 35);

    }
}