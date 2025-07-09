using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVizColor : MonoBehaviour
{
    [SerializeField] private GameObject vizObject; // Assign this in the Inspector
    [SerializeField] private Color newColor; // Default color

    public void ChangeOurColor()
    {
        var vizRenderer = vizObject.GetComponent<Renderer>();
        
        if (vizObject != null)
        {
            Debug.Log("changing colour...");
            vizRenderer.material.SetColor("_BaseColor", newColor);
        }
        else
        {
            Debug.LogWarning("Target material is not assigned.");
        }
    }
}
