using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate(){

        if (target != null){

            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

            transform.position = new Vector3(Mathf.Clamp(target.position.x, minX, maxX), Mathf.Clamp(target.position.y, maxY, minY), transform.position.z);
        }
    }
}
