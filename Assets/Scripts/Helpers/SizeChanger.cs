using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChanger
{
    private float _newSize = 0.5f;

    public void ChangeSize(GameObject gameObject)
    {
        gameObject.transform.localScale = new Vector3(
            gameObject.transform.localScale.x * _newSize, 
            gameObject.transform.localScale.y * _newSize, 
            gameObject.transform.localScale.z * _newSize
        );
    }
}
