using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IChildrenStorage))]
public class ExplodableTrait : MonoBehaviour, IClickHandler
{
    [SerializeField] private float _radius = 50;
    [SerializeField] private float _force = 800;

    public void HandleClick()
    {
        IReadOnlyList<Collider> children = GetComponent<IChildrenStorage>().GetChildren();

        foreach (Collider collider in children)
        {
            if (collider.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(_force, transform.position, _radius);
            }
        }

        Destroy(gameObject);
    }
}
