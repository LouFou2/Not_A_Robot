using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyCopyMovement : MonoBehaviour
{
    [SerializeField] private GetRigidBodyData handData; // assign in inspector
    [SerializeField] private GameObject targetObject;

    [SerializeField] private Vector3 proxyPos;
    [SerializeField] private Vector3 proxyOffset;

    void Start()
    {
        // set up the offset of the proxy object to the target object (this script is attached to the proxy object)
        proxyOffset = handData.GetRBPos() - gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = handData.GetRBPos();// + proxyOffset;
    }
}
