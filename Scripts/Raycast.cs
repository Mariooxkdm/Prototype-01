using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    private GameObject rayCastedObj;
    [SerializeField] private int rayLength = 10;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private Image uiCrosshair;

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if(Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
        {

        }
    }
}
         