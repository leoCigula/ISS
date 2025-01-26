using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pucanje : MonoBehaviour
{
     public Rigidbody Shell; // The shell prefab
    public Transform FireStart; // The point where the shell is fired from
    public float shellLifeTime = 5.0f; // Time before the shell is destroyed
    public float shellSpeed = 40.0f; // Speed of the shell
    public GameObject explosionEffectPrefab; // Explosion particle effect prefab

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


        // Add collision handling for the shell
        var shellHandler = newShell.gameObject.AddComponent<ShellCollisionHandler>();
        shellHandler.explosionEffectPrefab = explosionEffectPrefab; // Pass the explosion effect prefab
        //Destroy(newShell.gameObject, shellLifeTime); // Destroy shell after it expires
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
    public GameObject explosionEffectPrefab; // Explosion particle effect prefab

    void OnCollisionEnter(Collision collision)
    {
        // Instantiate the explosion effect at the point of collision
        if (explosionEffectPrefab != null)
        {
            GameObject explosion = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);

            // Destroy the explosion effect after it has played for its duration
            Destroy(explosion, 2.0f); // Adjust the time according to the duration of your explosion effect
        }

        // Destroy the shell upon collision
        Destroy(gameObject);
    }
}
