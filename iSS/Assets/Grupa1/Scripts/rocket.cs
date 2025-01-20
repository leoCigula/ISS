using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    private Transform cameraTransform;
    private Rigidbody rb;
    [SerializeField] private float movementSpeed = 25;
    [SerializeField] private float rotateSpeed = 5;
    [SerializeField] private ParticleSystem explosionPrefab;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {

        rb.velocity = transform.forward * movementSpeed;

        RotateMissile();
    }

    private void RotateMissile()
    {
        var direction = cameraTransform.forward;

        var rotation = Quaternion.LookRotation(direction);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed * Time.fixedDeltaTime));

    }

    public void SetCameraTransform(Transform camera)
    {
        cameraTransform = camera;
    }
}
