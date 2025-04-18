using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DivisibleTrait : MonoBehaviour
{
    [SerializeField] private float _spawnRadius = 5;
    [SerializeField] private int _minChildrenAmount = 2;
    [SerializeField] private int _maxChildrenAmount = 6;
    [SerializeField] private float _divisionChanceInPercent = 100;
    [SerializeField] private float _divisionChangeModifier = 0.5f;

    public float DivisionChanceInPercent => _divisionChanceInPercent;
    public float SpawnRadius => _spawnRadius;

    public void DecreaseDivisionChance()
    {
        _divisionChanceInPercent *= _divisionChangeModifier;
    }

    public int GetChildrenAmount()
    {
        return RandomHelper.GetRandomNumber(_minChildrenAmount, _maxChildrenAmount);
    }
}
