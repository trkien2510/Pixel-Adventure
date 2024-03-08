using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    Transform target;
    Vector3 positonOffset = new Vector3(0, 0, -10);

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = target.position + positonOffset;
    }
}
