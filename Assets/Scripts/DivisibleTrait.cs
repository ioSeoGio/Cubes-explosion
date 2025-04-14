using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DivisibleTrait : MonoBehaviour, IClickHandler
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _spawnRadius = 5;
    [SerializeField] private int _minChildrenAmount = 2;
    [SerializeField] private int _maxChildrenAmount = 6;
    [SerializeField] public int _divisionChanceInPercent = 100;

    public event Action<GameObject> ChildCreated;

    public void HandleClick()
    {
        Debug.Log("[2] Chance: " + _divisionChanceInPercent);

        if (RandomHelper.IsRandomEventHappened(_divisionChanceInPercent))
        {
            int childrenAmount = RandomHelper.GetRandomNumber(_minChildrenAmount, _maxChildrenAmount);

            for (int i = 0; i < childrenAmount; i++)
            {
                GameObject newObject = Instantiate(
                    _prefab, 
                    transform.position + UnityEngine.Random.insideUnitSphere * _spawnRadius, 
                    Quaternion.identity
                ) as GameObject;
                ChildCreated?.Invoke(newObject);

                DivisibleTrait script = newObject.GetComponent<DivisibleTrait>();
                script._divisionChanceInPercent = this._divisionChanceInPercent / 2;
            }
        }
    }
}
