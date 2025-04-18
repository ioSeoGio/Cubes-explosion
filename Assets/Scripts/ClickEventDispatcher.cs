using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CameraRaycastSelector))]
public class ClickEventDispatcher : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CameraRaycastSelector selector = GetComponent<CameraRaycastSelector>();
            GameObject gameObject = selector.GetObject();

            if (gameObject != null)
            {
                IReadOnlyList<Collider> children = new List<Collider>().AsReadOnly();
                if (gameObject.TryGetComponent<DivisibleTrait>(out DivisibleTrait divisibleTrait))
                {
                    DivisibleHandler divisibleHandler = gameObject.AddComponent<DivisibleHandler>();
                    children = divisibleHandler.Divide(divisibleTrait);
                }

                if (gameObject.TryGetComponent<ExplodableTrait>(out ExplodableTrait explodableTrait))
                {
                    ExplodableHandler explodableHandler = gameObject.AddComponent<ExplodableHandler>();
                    explodableHandler.Explode(explodableTrait, children);
                }
            }
        }
    }
}