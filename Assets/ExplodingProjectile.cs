using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingProjectile : MonoBehaviour {
    Rigidbody ProjectileRigidbody;
    public float ExplosionForce;
    public float ExplosionRadius;
    public float UpwardsModifier;
    public GameObject Explosion;
    private void Start()
    {
        ProjectileRigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Test");
        if (collision.gameObject.CompareTag("Explodeable"))
        {

            Debug.Log("Explode");
            GameObject newPrefab = Instantiate(Explosion, this.transform.position, this.transform.rotation);
            newPrefab.GetComponent<Explosion>().Explode(ExplosionForce, collision.contacts[0].point, ExplosionRadius,UpwardsModifier);
            Destroy(gameObject);
        }
    }

}
