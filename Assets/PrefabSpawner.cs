using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour {
	public CameraFollow ammoCamera;
public void SpawnPrefab(GameObject prefab){
		GameObject newPrefab = Instantiate(prefab, this.transform.position, this.transform.rotation);
		ammoCamera.SetTarget(newPrefab);
}

}
