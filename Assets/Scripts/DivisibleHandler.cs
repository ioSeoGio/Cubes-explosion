using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DivisibleHandler: MonoBehaviour
{
    [SerializeField] private float _spawnRadius = 5;
    [SerializeField] private int _minChildrenAmount = 2;
    [SerializeField] private int _maxChildrenAmount = 6;
    [SerializeField] public float _divisionChanceInPercent = 100;
    [SerializeField] public float _divisionChangeModifier = 0.5f;

    public IReadOnlyList<Collider> Divide(DivisibleTrait divisibleObject)
    {
        List<Collider> children = new List<Collider>();
        
        if (RandomHelper.IsRandomEventHappened(divisibleObject.DivisionChanceInPercent))
        {
            int childrenAmount = divisibleObject.GetChildrenAmount();
            ObjectSpawner objectSpawner = this.AddComponent<ObjectSpawner>();

            for (int i = 0; i < childrenAmount; i++)
            {
                DivisibleTrait newObject = objectSpawner.Spawn(divisibleObject, divisibleObject.transform.position, divisibleObject.SpawnRadius);
                children.Add(newObject.GetComponent<Collider>());
                newObject.DecreaseDivisionChance();
            }
        }

        return children;
    }
}
