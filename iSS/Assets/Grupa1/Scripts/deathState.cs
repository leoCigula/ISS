using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathState : MonoBehaviour
{
    private bool died = false;

    public GameObject ragdollPrefab;

    public GameObject rocketLauncherDrop;

    public GameObject kapsula;

    public GameObject model;

    public AudioSource scream;
    private Transform bodyPosition;
    private string headPositionPath = "Ch15_SwatSoldier/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:Neck/mixamorig:Head";

    [SerializeField] private Camera TPCamera;

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
            GetComponent<MovementState>().enabled = false;
            GetComponent<ShootingState>().enabled = false;

            //kapsula.GetComponent<CapsuleCollider>().enabled = false;
            //Destroy(kapsula);

            kapsula.GetComponent<CharacterController>().enabled = false;

            model.SetActive(false);


            GameObject doll = Instantiate(ragdollPrefab, transform);
            bodyPosition = doll.transform.Find(headPositionPath);
            //Debug.Log(bodyPosition);
            GameObject launcher = Instantiate(rocketLauncherDrop, transform);

            scream.Play();
            //doll.transform.parent = gameObject.transform.parent;
        }
        TPCamera.transform.LookAt(bodyPosition);
    }
}
