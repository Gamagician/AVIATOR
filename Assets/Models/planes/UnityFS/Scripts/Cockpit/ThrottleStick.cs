//
// UnityFS - Flight Simulation Toolkit. Copyright 2013 Chris Cheetham.
//

using UnityEngine;
using System.Collections;

[AddComponentMenu("UnityFS/Cockpit/Throttle Stick")]
public class ThrottleStick : MonoBehaviour 
{
	public string  ThrottleInput = "";
	public float MaxDeflectionDegrees = 15.0f;
	public Vector3 ThrottleAxis = new Vector3( 1.0f, 0.0f, 0.0f );

	private Quaternion InitialRotation = Quaternion.identity;
	
	// Use this for initialization
	void Start () 
	{
		ThrottleAxis.Normalize();
		InitialRotation = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ( "" != ThrottleInput )
		{
			float throttleAmount = Input.GetAxis(ThrottleInput);
			throttleAmount = Mathf.Clamp( throttleAmount, 0.0f, 1.0f );
			throttleAmount *= MaxDeflectionDegrees;
			transform.localRotation = InitialRotation;
			transform.Rotate( ThrottleAxis, throttleAmount );
		}
	}
}
