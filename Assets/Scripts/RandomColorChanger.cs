using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(IObjectCreator))]
public class RandomColorChanger : MonoBehaviour
{
    public void OnEnable()
    {
        IObjectCreator dispatcher = GetComponent<IObjectCreator>();
        dispatcher.ChildCreated += ChangeColor;
    }

    public void OnDisable()
    {
        IObjectCreator dispatcher = GetComponent<IObjectCreator>();
        dispatcher.ChildCreated -= ChangeColor;
    }

    private void ChangeColor(GameObject gameObject)
    {
        if (gameObject.TryGetComponent<Renderer>(out Renderer renderer))
        {
            renderer.material.color = RandomHelper.GetRandomColor();
        }
    }
}
