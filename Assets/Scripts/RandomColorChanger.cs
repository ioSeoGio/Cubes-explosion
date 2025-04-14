using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomColorChanger : MonoBehaviour
{
    public void OnEnable()
    {
        DivisibleTrait dispatcher = GetComponent<DivisibleTrait>();
        dispatcher.ChildCreated += ChangeColor;
    }

    public void OnDisable()
    {
        DivisibleTrait dispatcher = GetComponent<DivisibleTrait>();
        dispatcher.ChildCreated -= ChangeColor;
    }

    private void ChangeColor(GameObject gameObject)
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();

        if (renderer != null)
        {
            Debug.Log("[3] Changing object color");

            Material newMaterial = new Material(renderer.material);
            newMaterial.color = RandomHelper.GetRandomColor();
            renderer.material = newMaterial;
        }
    }
}
