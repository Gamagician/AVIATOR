//
// UnityFS - Flight Simulation Toolkit. Copyright 2013 Chris Cheetham.
//


using UnityEngine;
using System.Collections;

[AddComponentMenu("UnityFS/External/Steerable Nosewheel")]
public class SteerableNosewheel : MonoBehaviour 
{
	public string SteerInput = "Rudder";
	public float MaxDeflectionDegrees = 30.0f;
	public Vector3 SteerAxis = Vector3.up;
	public GameObject Model = null;
	public Vector3 ModelRotationAxis = Vector3.up;
	
	private Quaternion InitialRotation = Quaternion.identity;
	private Quaternion InitialModelRotation = Quaternion.identity;
	
	// Use this for initialization
	void Start () 
	{
		SteerAxis.Normalize();
		ModelRotationAxis.Normalize();
		
		InitialRotation = transform.localRotation;
		
		if ( null != Model )
		{
			InitialModelRotation = Model.transform.localRotation;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ( SteerInput != "" )
		{
			float steer = Input.GetAxis(SteerInput) * MaxDeflectionDegrees;
			transform.localRotation = InitialRotation;
			transform.Rotate( SteerAxis, steer );
			
			if ( null != Model )
			{
				Model.transform.localRotation = InitialModelRotation;
				Model.transform.Rotate( ModelRotationAxis, steer );
			}
		}
	}
}
