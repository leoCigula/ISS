using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class deathState : MonoBehaviour
{
    private bool died = false;

    public GameObject ragdollPrefab;

    public GameObject rocketLauncherDrop;

    public GameObject kapsula;

    public GameObject model;

    public AudioSource scream;

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

            kapsula.GetComponent<CapsuleCollider>().enabled = false;
            Destroy(kapsula);
            model.SetActive(false);


            GameObject doll = Instantiate(ragdollPrefab, transform);
            GameObject launcher = Instantiate(rocketLauncherDrop, transform);

            scream.Play();
            //doll.transform.parent = gameObject.transform.parent;

        }
    }
}
