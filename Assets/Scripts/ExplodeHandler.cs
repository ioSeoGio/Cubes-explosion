using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodableHandler
{
    public void Explode(ExplodableTrait explodingObject, IReadOnlyList<Collider> collidersToImpact)
    {
        foreach (Collider collider in collidersToImpact)
        {
            if (collider.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(explodingObject.Force, explodingObject.transform.position, explodingObject.Radius);
            }
        }

        GameObject.Destroy(explodingObject.gameObject);
    }
}
