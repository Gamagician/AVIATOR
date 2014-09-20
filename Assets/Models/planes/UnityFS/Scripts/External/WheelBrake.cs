//

// UnityFS - Flight Simulation Toolkit. Copyright 2013 Chris Cheetham.
//

using UnityEngine;
using System.Collections;


[AddComponentMenu("UnityFS/External/Wheel Brake")]
[RequireComponent( typeof(WheelCollider) )]
public class WheelBrake : MonoBehaviour 
{
	public string WheelBrakeInputAxis = "";
	public float BrakeTorque = 10000.0f;
	
	private WheelCollider Wheel = null;
	
	// Use this for initialization
	void Start () 
	{
		Wheel = GetComponent<WheelCollider>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Brakes the attached wheel if key pressed.
		if ( (null != Wheel) && ("" != WheelBrakeInputAxis) )
		{
			if ( Input.GetButton(WheelBrakeInputAxis) )
			{
				Wheel.brakeTorque = BrakeTorque;
			}
			else
			{
				Wheel.brakeTorque = 0.0f;
			}
		}
	}
}
