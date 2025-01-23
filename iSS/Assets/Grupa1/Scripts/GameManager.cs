using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    private MovementState movementState;
    private CharacterController cc;
    private ShootingState shootingState;
    [SerializeField] private GameObject aimCanvas;
    // Start is called before the first frame update
    void Start()
    {
        if(aimCanvas)
            aimCanvas.SetActive(false);
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            movementState = player.GetComponent<MovementState>();
            shootingState = player.GetComponent<ShootingState>();
            cc = player.GetComponent<CharacterController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shootingState.enabled)
        {
            aimCanvas.SetActive(true);
            cc.height = 12;
            cc.center = new Vector3(cc.center.x, -10, cc.center.z);
        }
        else
        {
            aimCanvas.SetActive(false);
            cc.height = 16.9f;
            cc.center = new Vector3(cc.center.x, -7.37f, cc.center.z);
        }
    }
}
