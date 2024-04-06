using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Transform target;
    Vector3 positonOffset = new(0, 0, -10);

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            Vector3 CameraPosition = target.position;
            transform.position = CameraPosition + positonOffset;
        }
    }
}
