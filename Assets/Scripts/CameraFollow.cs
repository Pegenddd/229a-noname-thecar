using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; // Drag your PlayerCar here

    [Header("Distance Settings")]
    public float distance = 10f; // How far back from the car
    public float height = 5f;    // How high above the car

    [Header("Follow Movement")]
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        // Safety check: If target is not assigned, do nothing
        if (target == null) return; 

        // Calculate desired position relative to target's direction
        // Uses -target.forward to stay behind and target.up to stay above
        Vector3 desiredPosition = target.position - (target.forward * distance) + (target.up * height);
        
        // Smoothly move the camera to the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        
        // Always point the camera towards the target
        transform.LookAt(target);
    }
}