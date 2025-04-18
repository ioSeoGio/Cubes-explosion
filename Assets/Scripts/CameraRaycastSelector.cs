using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycastSelector : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask selectableLayer;

    public GameObject GetObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, selectableLayer))
        {
            return hit.collider.gameObject;
        }

        return null;
    }
}
