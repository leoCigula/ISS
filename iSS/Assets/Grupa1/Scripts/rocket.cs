using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    private Transform cameraTransform;
    private Rigidbody rb;
    private Vector3 spawnPoint;
    [SerializeField] private float movementSpeed = 80f;
    [SerializeField] private float maxSpeed = 186f;
    [SerializeField] private float acceleration = 15f;
    [SerializeField] private float drag = 0.1f;
    [SerializeField] private float rotateSpeed = 5;
    [SerializeField] private float rotationDeviation = 0.02f;
    [SerializeField] private ParticleSystem tankExplosionPrefab;
    [SerializeField] private ParticleSystem terrainExplosionPrefab;
    [SerializeField] private ParticleSystem waterExplosionPrefab;

    private void Start()
    {
        spawnPoint = transform.position;
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Tank"))
            {
                Instantiate(tankExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                rb.velocity = Vector3.zero;
                StartCoroutine(ExplodeAfterDelay(2f));
                //Instantiate(waterExplosionPrefab, transform.position, Quaternion.identity);
                //Destroy(gameObject);
            }
            else
            {
                Instantiate(terrainExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
       
    }

    private void FixedUpdate()
    {
        UpdateSpeed();
        rb.velocity = transform.forward * movementSpeed;

        RotateMissile();

        if(Vector3.Distance(transform.position, spawnPoint) > 3000f)
        {
            Destroy(gameObject);
        }
    }

    private void RotateMissile()
    {
        var direction = cameraTransform.forward;

        var rotation = Quaternion.LookRotation(direction);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed * Time.fixedDeltaTime));

    }

    private void UpdateSpeed()
    {
        if(movementSpeed < maxSpeed)
        {
            movementSpeed += acceleration * Time.fixedDeltaTime;
        }
        else
        {
            var temp = movementSpeed - drag * Time.fixedDeltaTime;
            movementSpeed = Mathf.Max(temp, 0);
        }
    }

    public void SetCameraTransform(Transform camera)
    {
        cameraTransform = camera;
    }

    private IEnumerator ExplodeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        Instantiate(waterExplosionPrefab, transform.position, Quaternion.identity); // Create the water explosion
        Destroy(gameObject); // Destroy the missile
    }
}
