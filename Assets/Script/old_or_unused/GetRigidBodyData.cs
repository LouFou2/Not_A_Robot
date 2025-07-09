using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRigidBodyData : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 worldPosition = Vector3.zero;
    private Quaternion worldRotation = Quaternion.identity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody not found on this GameObject.");
            enabled = false; // Disable the script if no Rigidbody is found.
        }
    }

    void FixedUpdate()
    {
        // Get the Rigidbody's world space position.
        worldPosition = rb.transform.position;

        // Get the Rigidbody's world space rotation.
        worldRotation = rb.transform.rotation;

        /*// Get the current velocity
        Vector3 currentVelocity = rb.velocity;

        // Access individual components of the velocity
        float xVelocity = currentVelocity.x;
        float yVelocity = currentVelocity.y;
        float zVelocity = currentVelocity.z;

        // You can also access the velocity magnitude (speed)
        float speed = currentVelocity.magnitude;
        
        Debug.Log("World Position: " + worldPosition);
        Debug.Log("World Rotation: " + worldRotation.eulerAngles); // Convert Quaternion to Euler angles for easier readability.

        // Print the velocity components
        Debug.Log("Velocity: " + currentVelocity);
        Debug.Log("X Velocity: " + xVelocity);
        Debug.Log("Y Velocity: " + yVelocity);
        Debug.Log("Z Velocity: " + zVelocity);
        Debug.Log("Speed: " + speed);*/
    }

    public Vector3 GetRBPos()
    {
        return worldPosition;
    }

    public Quaternion GetRBRot()
    {
        return worldRotation;
    }
}
