using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyCopyMovement2 : MonoBehaviour
{
    [SerializeField] private GetObjectData targetObjectData;

    [SerializeField] private Vector3 proxyPos;
    [SerializeField] private Vector3 proxyOffset;

    void Start()
    {
        // set up the offset of the proxy object to the target object (this script is attached to the proxy object)
        proxyOffset = targetObjectData.GetTargetPos() - gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = targetObjectData.GetTargetPos();// + proxyOffset;
    }



}
