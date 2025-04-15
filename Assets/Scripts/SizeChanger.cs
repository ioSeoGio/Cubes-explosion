using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IObjectCreator))]
public class SizeChanger : MonoBehaviour
{
    [SerializeField] private float _newSize = 0.5f;

    public void OnEnable()
    {
        IObjectCreator dispatcher = GetComponent<IObjectCreator>();
        dispatcher.ChildCreated += ChangeSize;
    }

    public void OnDisable()
    {
        IObjectCreator dispatcher = GetComponent<IObjectCreator>();
        dispatcher.ChildCreated -= ChangeSize;
    }

    private void ChangeSize(GameObject gameObject)
    {
        gameObject.transform.localScale = new Vector3(
            transform.localScale.x * _newSize, 
            transform.localScale.y * _newSize, 
            transform.localScale.z * _newSize
        );
    }
}
