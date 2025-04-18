using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodableTrait : MonoBehaviour
{
    [SerializeField] private float _radius = 50;
    [SerializeField] private float _force = 800;

    public float Radius => _radius;
    public float Force => _force;
}
