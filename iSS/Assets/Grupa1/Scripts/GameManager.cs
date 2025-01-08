using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    private movementState movementState;
    private shootingState shootingState;
    [SerializeField] private GameObject aimCanvas;
    // Start is called before the first frame update
    void Start()
    {
        if(aimCanvas)
            aimCanvas.SetActive(false);
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            movementState = player.GetComponent<movementState>();
            shootingState = player.GetComponent<shootingState>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shootingState.enabled)
        {
            aimCanvas.SetActive(true);
        }
        else
        {
            aimCanvas.SetActive(false);
        }
    }
}
