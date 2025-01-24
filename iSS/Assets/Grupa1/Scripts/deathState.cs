using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class deathState : MonoBehaviour
{
    private bool died = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (died == false)
        {
            died = true;
            GetComponent<MovementState>().setCamera();
            GetComponent<MovementState>().enabled = false;
            GetComponent<ShootingState>().enabled = false;
        }
    }
}
