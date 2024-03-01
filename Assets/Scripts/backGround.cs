using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class backGround : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
