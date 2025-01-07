using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingState : MonoBehaviour
{
    public MonoBehaviour movementState;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void exitState()
    {
            movementState.enabled = true;
            enabled = false;
    }

}
