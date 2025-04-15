using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DivisibleTrait : MonoBehaviour, IClickHandler, IObjectCreator
{
    [SerializeField] private DivisibleTrait _prefab;
    [SerializeField] private float _spawnRadius = 5;
    [SerializeField] private int _minChildrenAmount = 2;
    [SerializeField] private int _maxChildrenAmount = 6;
    [SerializeField] public float _divisionChanceInPercent = 100;
    [SerializeField] public float _divisionChangeModifier = 0.5f;

    public float DivisionChanceInPercent
    {
        set
        {
            _divisionChanceInPercent = Math.Max(value, 0);
        }
    }

    public event Action<GameObject> ChildCreated;

    public void HandleClick()
    {
        if (RandomHelper.IsRandomEventHappened(_divisionChanceInPercent))
        {
            int childrenAmount = RandomHelper.GetRandomNumber(_minChildrenAmount, _maxChildrenAmount);

            for (int i = 0; i < childrenAmount; i++)
            {
                DivisibleTrait newObject = ObjectSpawner.Spawn(_prefab, transform.position, _spawnRadius);
                ChildCreated?.Invoke(newObject.gameObject);

                newObject.DivisionChanceInPercent = _divisionChanceInPercent * _divisionChangeModifier;
            }
        }
    }
}
