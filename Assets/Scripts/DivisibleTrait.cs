using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DivisibleTrait : MonoBehaviour, IClickHandler, IChildrenStorage
{
    [SerializeField] private DivisibleTrait _prefab;
    [SerializeField] private float _spawnRadius = 5;
    [SerializeField] private int _minChildrenAmount = 2;
    [SerializeField] private int _maxChildrenAmount = 6;
    [SerializeField] public float _divisionChanceInPercent = 100;
    [SerializeField] public float _divisionChangeModifier = 0.5f;

    private List<Collider> _children = new List<Collider>();

    public float DivisionChanceInPercent
    {
        set
        {
            _divisionChanceInPercent = Math.Max(value, 0);
        }
    }

    public void HandleClick()
    {
        if (RandomHelper.IsRandomEventHappened(_divisionChanceInPercent))
        {
            int childrenAmount = RandomHelper.GetRandomNumber(_minChildrenAmount, _maxChildrenAmount);
            ObjectSpawner objectSpawner = new ObjectSpawner();

            for (int i = 0; i < childrenAmount; i++)
            {
                DivisibleTrait newObject = objectSpawner.Spawn(_prefab, transform.position, _spawnRadius);
                _children.Add(newObject.GetComponent<Collider>());
                newObject.DivisionChanceInPercent = _divisionChanceInPercent * _divisionChangeModifier;
            }
        }
    }

    public IReadOnlyList<Collider> GetChildren()
    {
        return _children.AsReadOnly();
    }
}
