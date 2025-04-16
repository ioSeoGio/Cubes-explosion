using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public T Spawn<T>(T prefab, Vector3 position, float spawnRadius) where T : MonoBehaviour
    {
        T newObject = Instantiate(prefab, position + Random.insideUnitSphere * spawnRadius, Quaternion.identity);

        SizeChanger sizeChanger = new SizeChanger();
        RandomColorChanger randomColorChanger = new RandomColorChanger();

        sizeChanger.ChangeSize(newObject.gameObject);
        randomColorChanger.ChangeColor(newObject.gameObject);

        return newObject;
    }
}
