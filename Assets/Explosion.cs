using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
    }
    public void Explode(float ExplosionForce,Vector3 ExplodingPoint,float ExplosionRadius, float UpwardsModifier)
    {
        
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, ExplosionRadius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                rb.AddExplosionForce(ExplosionForce, ExplodingPoint, ExplosionRadius, UpwardsModifier);
        }
        Destroy(gameObject, 2f);
    }
}
