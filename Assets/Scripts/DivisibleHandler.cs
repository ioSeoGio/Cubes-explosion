using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DivisibleHandler
{
    private ObjectSpawner _objectSpawner = new();

    public IReadOnlyList<Collider> Divide(DivisibleTrait divisibleObject)
    {
        List<Collider> children = new List<Collider>();
        
        if (RandomHelper.IsRandomEventHappened(divisibleObject.DivisionChanceInPercent))
        {
            int childrenAmount = divisibleObject.GetChildrenAmount();

            for (int i = 0; i < childrenAmount; i++)
            {
                DivisibleTrait newObject = _objectSpawner.Spawn(divisibleObject, divisibleObject.transform.position, divisibleObject.SpawnRadius);
                children.Add(newObject.GetComponent<Collider>());
                newObject.DecreaseDivisionChance();
            }
        }

        return children;
    }
}
