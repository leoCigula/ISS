using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pucanje : MonoBehaviour
{
    public Rigidbody Shell; // The shell prefab
    public Transform FireStart; // The point where the shell is fired from
    public float shellLifeTime = 5.0f; // Time before the shell is destroyed
    public float shellSpeed = 40.0f; // Speed of the shell
    public bool ignoreGravity = true; // Option to ignore gravity for the shell

    private Transform cannon;

    void Start()
    {
        cannon = FireStart.parent;
    }

    public void Shoot()
    {
        
        Rigidbody newShell = Instantiate(Shell, FireStart.position, cannon.rotation);

        
        newShell.velocity = shellSpeed * cannon.forward;

        
        Destroy(newShell.gameObject, shellLifeTime);

        Debug.Log("Shell fired!");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Shoot();
        }
    }
}
