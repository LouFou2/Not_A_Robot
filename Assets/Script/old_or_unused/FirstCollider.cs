using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FirstCollider : MonoBehaviour
{
    public UnityEvent CollideWithBox;

    

    void OnTriggerEnter(Collider other)
    {
        // Invoke the UnityEvent without any tag check
        CollideWithBox.Invoke();

    }
}
