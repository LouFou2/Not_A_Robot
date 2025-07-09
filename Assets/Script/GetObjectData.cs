using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObjectData : MonoBehaviour
{
    [SerializeField] private Vector3 worldPosition;
    [SerializeField] private Quaternion worldRotation;

    void Update()
    {
        worldPosition = gameObject.transform.position;
        worldRotation = gameObject.transform.rotation;
    }

    public Vector3 GetTargetPos()
    {
        return worldPosition;
    }

    public Quaternion GetTargetRot()
    {
        return worldRotation;
    }
}


