using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolaKupole : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float minAngle = -360f;     
    public float maxAngle = 360f;      

    private float currentRotation = 0f; 

    void Update()
    {
        float rotationInput = 0f;

        // Rotate based on input
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotationInput = -rotationSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotationInput = rotationSpeed * Time.deltaTime;
        }

        currentRotation += rotationInput;
        currentRotation = Mathf.Clamp(currentRotation, minAngle, maxAngle);

       
        transform.localEulerAngles = new Vector3(0f, currentRotation, 0f);
    }
}
