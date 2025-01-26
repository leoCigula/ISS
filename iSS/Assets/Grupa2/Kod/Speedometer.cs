using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public Rigidbody target;

    public float maxSpeed = 60f;

    public float minSpeedArrowAngle;
    public float maxSpeedArrowAngle;

    [Header("UI")]
    public RectTransform arrow;

    private float speed = 0.0f;

    private void Update()
    {
        
        speed = target.velocity.magnitude*3.6f;
        //if (target.velocity.magnitude!=0)Debug.Log($"Brzina: {speed}, Velocity {target.velocity.magnitude}, Rezultat: {speed/maxSpeed*10}");

        if (arrow != null)
        arrow.localEulerAngles = new Vector3(0,0,Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, speed/maxSpeed));
    }
}
