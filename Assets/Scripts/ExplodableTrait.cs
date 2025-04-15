using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodableTrait : MonoBehaviour, IClickHandler
{
    [SerializeField] private float _radius = 50;
    [SerializeField] private float _force = 800;

    public void HandleClick()
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

        Destroy(gameObject);
    }
}
