using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CameraRaycastSelector))]
public class ClickEventDispatcher : MonoBehaviour
{
    private CameraRaycastSelector _cameraRaycastSelector;
    private DivisibleHandler _divisibleHandler = new();
    private ExplodableHandler _explodableHandler = new();

    private void Start()
    {
        _cameraRaycastSelector = GetComponent<CameraRaycastSelector>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject gameObject = _cameraRaycastSelector.GetObject();

            if (gameObject != null)
            {
                IReadOnlyList<Collider> children = new List<Collider>().AsReadOnly();

                if (gameObject.TryGetComponent<DivisibleTrait>(out DivisibleTrait divisibleTrait))
                {
                    children = _divisibleHandler.Divide(divisibleTrait);
                }

                if (gameObject.TryGetComponent<ExplodableTrait>(out ExplodableTrait explodableTrait))
                {
                    _explodableHandler.Explode(explodableTrait, children);
                }
            }
        }
    }
}