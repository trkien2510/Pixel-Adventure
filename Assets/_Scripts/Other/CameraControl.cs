using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Transform target;
    Vector3 positonOffset = new(0, 0, -10);

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 CameraPosition = target.position;
        transform.position = CameraPosition + positonOffset;
    }
}
