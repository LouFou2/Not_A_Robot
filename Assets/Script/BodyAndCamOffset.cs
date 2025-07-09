using UnityEngine;

public class BodyAndCamOffset : MonoBehaviour
{
    [SerializeField] private Transform target;  // The GameObject to follow (Camera)
    [SerializeField] private Vector3 positionOffset;  // Offset to apply

    void LateUpdate()
    {
        if (target != null)
        {
            // Update this object's position to match the target's position plus the offset
            transform.position = target.position + positionOffset;
        }
    }
}
