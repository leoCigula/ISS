using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pucanje : MonoBehaviour
{
     public Rigidbody Shell; 
    public Transform FireStart; 
    public float shellLifeTime = 5.0f; 
    public float shellSpeed = 40.0f; 
    public GameObject explosionEffectPrefab;
    public AudioSource audioClip;
    private Transform cannon;

    void Start()
    {
        cannon = FireStart.parent;
    }

    public void Shoot()
    {
        Rigidbody newShell = Instantiate(Shell, FireStart.position, cannon.rotation);
        newShell.velocity = shellSpeed * cannon.forward;

         newShell.collisionDetectionMode = CollisionDetectionMode.Continuous;

        audioClip.Play();
       
        var shellHandler = newShell.gameObject.AddComponent<ShellCollisionHandler>();
        shellHandler.explosionEffectPrefab = explosionEffectPrefab; 
        //Destroy(newShell.gameObject, shellLifeTime); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Shoot();
        }
    }

}

public class ShellCollisionHandler : MonoBehaviour
{
    public GameObject explosionEffectPrefab; 

    void OnCollisionEnter(Collision collision)
    {
        
        if (explosionEffectPrefab != null)
        {
            GameObject explosion = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);

            Destroy(explosion, 2.0f); 
        }

        
        Destroy(gameObject);
    }
}
