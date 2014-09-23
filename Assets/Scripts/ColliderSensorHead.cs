using UnityEngine;
using System.Collections;

public class ColliderSensorTail : MonoBehaviour
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
