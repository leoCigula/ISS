using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingState : MonoBehaviour
{
    [SerializeField] private MonoBehaviour movementState;
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float rocketSpeed = 25;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var rocket = Instantiate(rocketPrefab, spawnPoint.position, Quaternion.identity);
            rocket.GetComponent<Rigidbody>().AddForce(playerCamera.forward.normalized * rocketSpeed,ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(1))
        {
            movementState.enabled = true;
            enabled = false;
        }
    }


}
