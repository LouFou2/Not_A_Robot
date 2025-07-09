using System.Collections.Generic;
using UnityEngine;

public class TunnelInstancer : MonoBehaviour
{
    [SerializeField] private GameObject objectsCylinder;
    [SerializeField] private float spacingDistance = 2.0f;
    [SerializeField] private int forwardCylinderInstances = 3;
    [SerializeField] private int backwardCylinderInstances = 3;
    [SerializeField] private float tunnelMoveSpeed = 0.2f;
    [SerializeField] private float rotationOffset = 30f;

    private List<GameObject> tunnelSegments = new List<GameObject>();
    private float currentRotation = 0f;

    private void Start()
    {
        int total = forwardCylinderInstances + backwardCylinderInstances + 1;

        for (int i = -backwardCylinderInstances; i <= forwardCylinderInstances; i++)
        {
            Vector3 position = new Vector3(0, 0, i * spacingDistance);
            Quaternion rotation = Quaternion.Euler(0, 0, currentRotation);
            GameObject segment = Instantiate(objectsCylinder, position, rotation, transform);
            tunnelSegments.Add(segment);

            currentRotation += rotationOffset;
        }
    }

    private void Update()
    {
        MoveTunnel();

        if (tunnelSegments.Count == 0) return;

        GameObject firstSegment = tunnelSegments[0];
        if (firstSegment.transform.position.z < -backwardCylinderInstances * spacingDistance)
        {
            Destroy(firstSegment);
            tunnelSegments.RemoveAt(0);

            GameObject lastSegment = tunnelSegments[tunnelSegments.Count - 1];
            Vector3 newPosition = lastSegment.transform.position + new Vector3(0, 0, spacingDistance);
            Quaternion newRotation = Quaternion.Euler(0, 0, currentRotation);
            GameObject newSegment = Instantiate(objectsCylinder, newPosition, newRotation, transform);
            tunnelSegments.Add(newSegment);

            currentRotation += rotationOffset;
        }
    }

    private void MoveTunnel()
    {
        foreach (GameObject segment in tunnelSegments)
        {
            if (segment != null)
            {
                segment.transform.position += Vector3.back * tunnelMoveSpeed * Time.deltaTime;
            }
        }
    }
}
