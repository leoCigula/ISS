using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    public LogicScript logicScript;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "deadly")
        {
            logicScript.GameOver();
            if(name == "character")
                GetComponent<DeathState>().enabled = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "deadly")
        {
            logicScript.GameOver();
            if (name == "character")
                GetComponent<DeathState>().enabled = true;
        }

    }
}

