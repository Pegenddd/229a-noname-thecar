using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarMovement : MonoBehaviour
{
    [Header("Speed Settings")]
    public float forwardAcceleration = 5000f; 
    public float steerSpeed = 100f;

    [Header("Physics & Drag")]
    public float carDrag = 0.5f;       
    public float steerDrag = 3f;       
    public float gripStrength = 10f;   

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        
        rb.linearDamping = carDrag; 
        rb.angularDamping = steerDrag; 
    }

    void FixedUpdate()
    {
        float mass = rb.mass; 
        float verticalInput = Input.GetAxis("Vertical"); 
        float horizontalInput = Input.GetAxis("Horizontal"); 

        // Forward and Backward movement
        float forwardForce = mass * forwardAcceleration * verticalInput; 
        rb.AddForce(transform.forward * forwardForce);

        // Steering
        transform.Rotate(Vector3.up * horizontalInput * steerSpeed * verticalInput * Time.fixedDeltaTime);

        // Anti-slip grip system (ใช้ linearVelocity แทน velocity)
        float sidewaysSpeed = Vector3.Dot(transform.right, rb.linearVelocity);
        Vector3 gripForce = -transform.right * sidewaysSpeed * mass * gripStrength; 
        rb.AddForce(gripForce);
    }
}