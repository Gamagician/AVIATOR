//
// UnityFS - Flight Simulation Toolkit. Copyright 2013 Chris Cheetham.
//

using UnityEngine;
using System.Collections;

[AddComponentMenu("UnityFS/Base/AircraftCamera")]
public class AircraftCamera : MonoBehaviour 
{
	protected bool CameraActive = false;
	
	//Base class for all cameras.
	public void SetCameraActive( bool active )
	{
		CameraActive = active;
	}
	
}
