using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    [SerializeField] private float _newSize = 0.5f;

    public void OnEnable()
    {
        DivisibleTrait dispatcher = GetComponent<DivisibleTrait>();
        dispatcher.ChildCreated += ChangeSize;
    }

    public void OnDisable()
    {
        DivisibleTrait dispatcher = GetComponent<DivisibleTrait>();
        dispatcher.ChildCreated -= ChangeSize;
    }

    private void ChangeSize(GameObject gameObject)
    {
        Debug.Log("[4] Changing size");
        gameObject.transform.localScale = new Vector3(
            transform.localScale.x * _newSize, 
            transform.localScale.y * _newSize, 
            transform.localScale.z * _newSize
        );
    }
}
