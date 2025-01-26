using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassDirection : MonoBehaviour
{
    public Transform turret; 
    public RectTransform compassArrow; 
    public float offsetAngle = 272f; 

    void Update()
    {
        if (turret != null && compassArrow != null)
        {
           
            float turretRotationY = turret.localEulerAngles.y;

            
            if (turretRotationY > 180f)
            {
                turretRotationY -= 360f;
            }
           
            float adjustedRotation = -turretRotationY + offsetAngle;

            compassArrow.localEulerAngles = new Vector3(0f, 0f, adjustedRotation);
        }
    }
}
