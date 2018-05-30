using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour {
    public FixedJoint ProjectileJoint;
    public CameraFollow ammoCamera;

    private void Start()
    {
        ProjectileJoint = GetComponent<FixedJoint>();
    }
    public void SpawnPrefab(GameObject prefab){
		GameObject newPrefab = Instantiate(prefab, this.transform.position, this.transform.rotation);
		ammoCamera.SetTarget(newPrefab);
        ProjectileJoint.connectedBody = newPrefab.GetComponent<Rigidbody>();

    }

    public void CreateJoint()
    {
        ProjectileJoint = gameObject.AddComponent<FixedJoint>();
        ProjectileJoint.breakTorque = 500;
        ProjectileJoint.breakForce = 500;
    }
}
