using UnityEngine;
using System.Collections;

public class ColliderSensorLeft : MonoBehaviour
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
