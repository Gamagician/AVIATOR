using UnityEngine;
using System.Collections;

public class ColliderSensorRight : MonoBehaviour
{

    public bool Collided;


    void OnTriggerEnter()
    {
        Collided = true;
    }

    void OnTriggerExit()
    {
        Collided = false;
    }
}
