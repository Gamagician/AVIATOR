//
// UnityFS - Flight Simulation Toolkit. Copyright 2013 Chris Cheetham.
//

using UnityEngine;
using System.Collections;

[AddComponentMenu("UnityFS/Cockpit/Yoke")]
public class Yoke : AircraftAttachment 
{
	public string PitchInput = "Vertical";
	public string RollInput = "Horizontal";
	public float MaxPitchTranslationMeters = 0.3f;
	public float MaxRollDeflectionDegrees = 30.0f;
	public Vector3 PitchAxis = new Vector3( 0.0f, 0.0f, 1.0f );
	public Vector3 RollAxis = new Vector3( 0.0f, 0.0f, 1.0f );
	
	private Vector3 InitialPosition = Vector3.zero;
	private Quaternion InitialRotation = Quaternion.identity;
	
	// Use this for initialization
	void Start () 
	{
		PitchAxis.Normalize();
		RollAxis.Normalize();
		InitialPosition = transform.localPosition;
		InitialRotation = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ( Controllable )
		{
			if ( (PitchInput.Length > 0) && (RollInput.Length>0) )
			{
				//Pitch translation.
				float pitch = Input.GetAxis(PitchInput) * MaxPitchTranslationMeters;
				transform.localPosition = InitialPosition;
				transform.localPosition += PitchAxis * pitch;
				
				//Roll rotation
				float roll = Input.GetAxis(RollInput) * MaxRollDeflectionDegrees;
				transform.localRotation = InitialRotation;
				transform.Rotate( RollAxis, roll );	
			}
		}
	}
}
