using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AimDistance : MonoBehaviour
{
    public GameObject scopeCamera;
    public TextMeshProUGUI distanceText;
   // public LayerMask ignoreLayer;

    void Update()
    {
        Ray ray = new Ray(scopeCamera.transform.position,Quaternion.Euler(270, 0, 0) * scopeCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {

            Debug.Log($"Hit object: {hit.collider.gameObject.name}");
            float distance = Vector3.Distance(scopeCamera.transform.position, hit.point);
            distanceText.text = $"Distance: {distance:F1} m";
            distanceText.color = Color.green;

            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green);
        }
        else
        {
            distanceText.text = "";
            distanceText.color = Color.white;
        }
    }
}
