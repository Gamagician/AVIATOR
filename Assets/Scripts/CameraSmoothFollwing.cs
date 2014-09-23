using UnityEngine;
using System.Collections;

public class CameraSmoothFollwing : MonoBehaviour {

    public Transform target;
    public float distance = 3.0f;
    public float height = 3.0f;
    public float damping = 5.0f;
    public bool smoothRotation = true;
    public float rotationDamping = 10.0f;

    void Update()
    {
        var wantedPosition = target.TransformPoint(0, height, -distance);
        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

        if (smoothRotation)
        {
            var wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
        }

        else transform.LookAt(target, target.up);
    }

}
