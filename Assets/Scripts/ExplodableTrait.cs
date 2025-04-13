using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodableTrait : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _radius;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _force;
    [SerializeField] private int _minChildrenAmount = 2;
    [SerializeField] private int _maxChildrenAmount = 6;
    [SerializeField] public int divisionChanceInPercent = 100;

    public void SpawnChildren()
    {
        Debug.Log("Chance: " + divisionChanceInPercent);

        if (RandomHelper.IsRandomEventHappened(divisionChanceInPercent))
        {
            int childrenAmount = RandomHelper.GetRandomNumber(_minChildrenAmount, _maxChildrenAmount);

            for (int i = 0; i < childrenAmount; i++)
            {
                Debug.Log("Спавню дочерний куб");
                GameObject newObject = Instantiate(_prefab, transform.position + Random.insideUnitSphere * _spawnRadius, Quaternion.identity);
                newObject.transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z / 2);
                Renderer renderer = newObject.GetComponent<Renderer>();

                ExplodableTrait script = newObject.GetComponent<ExplodableTrait>();
                script.divisionChanceInPercent = this.divisionChanceInPercent / 2;

                if (renderer != null)
                {
                    Material newMaterial = new Material(renderer.material);
                    newMaterial.color = RandomHelper.GetRandomColor();
                    renderer.material = newMaterial;
                }
            }
        }

        Destroy(this.gameObject);
    }

    public void Explode()
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, _radius);

        foreach(Collider collider in overlappedColliders)
        {
            Rigidbody rigidbody = collider.attachedRigidbody;

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(_force, transform.position, _radius);
            }
        }
    }

    public void OnMouseDown()
    {
        Debug.Log("Cube was clicked");
        SpawnChildren();
        Explode();
    }
}
