using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float cameraHeight = 20.0f;
    public float cameraBehind = 10f;
    void Update()
    {

        Vector3 pos = player.transform.position;
        pos.z += cameraBehind;
        pos.y += cameraHeight;

        transform.position = pos;
               
    }
}
  

