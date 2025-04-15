using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public static T Spawn<T>(T prefab, Vector3 position, float spawnRadius) where T : MonoBehaviour
    {
        return Instantiate(prefab, position + Random.insideUnitSphere * spawnRadius, Quaternion.identity);
    }
}
