//
// UnityFS - Flight Simulation Toolkit. Copyright 2013 Chris Cheetham.
//

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

using System.Collections;

[AddComponentMenu("UnityFS/Helpers/Mirror Wing")]
[ExecuteInEditMode]
public class MirrorWing : MonoBehaviour 
{
#if UNITY_EDITOR	
	public Wing ParentWing = null;
	
	private Wing LocalWing = null;
	private ControlSurface LocalControlSurface = null;
	private PropWash LocalPropWash = null;
	
	// Use this for initialization
	void Start () 
	{
		LocalWing = GetComponent<Wing>();
		LocalControlSurface = GetComponent<ControlSurface>();
		LocalPropWash = GetComponent<PropWash>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Make sure we have a parent wing before we try and do anything and also make sure they are similarly parented.
		if ( (null != ParentWing) && (transform.root.gameObject == ParentWing.transform.root.gameObject) )
		{
			//Do not try and copy self.
			if ( this == ParentWing )
			{
				return;
			}
			
			//Copy name..
			gameObject.name = ParentWing.name + "(Mirror)";
			
			//First copy transforms..
			transform.localScale = new Vector3( -ParentWing.transform.localScale.x, ParentWing.transform.localScale.y, ParentWing.transform.localScale.z );
			transform.localPosition = ParentWing.transform.localPosition;
			transform.localPosition = new Vector3( -transform.localPosition.x, transform.localPosition.y, transform.localPosition.z );
			
			transform.localRotation = new Quaternion( -ParentWing.transform.localRotation.x,
														ParentWing.transform.localRotation.y,
														ParentWing.transform.localRotation.z,
														ParentWing.transform.localRotation.w * -1.0f);
			
			//Copy wing
			if ( !LocalWing && ParentWing )
			{
				LocalWing = gameObject.AddComponent<Wing>();
			}
			
			
			
			if ( LocalWing )
			{
				//EditorUtility.CopySerialized( ParentWing, LocalWing ); //**CRASHES ON 3.5
				
				LocalWing.SectionCount = ParentWing.SectionCount;
				LocalWing.WingTipWidthZeroToOne = ParentWing.WingTipWidthZeroToOne;
				LocalWing.WingTipSweep = ParentWing.WingTipSweep;
				LocalWing.WingTipAngle = ParentWing.WingTipAngle;
				LocalWing.Aerofoil = ParentWing.Aerofoil;
				LocalWing.CDOverride = ParentWing.CDOverride;
			}

			//Copy control surface
			ControlSurface parentControlSurface = ParentWing.GetComponent<ControlSurface>();
			if (!LocalControlSurface && parentControlSurface )
			{
				LocalControlSurface = gameObject.AddComponent<ControlSurface>();
			}
			if ( LocalControlSurface )
			{
				//string previousLocalAxisName = LocalControlSurface.AxisName;
				bool previousLocalInvert = LocalControlSurface.Invert;
				GameObject previousModel = LocalControlSurface.Model;
				Vector3 previousRotationAxis = LocalControlSurface.ModelRotationAxis;
				
				//EditorUtility.CopySerialized( parentControlSurface, LocalControlSurface ); //**CRASHES ON 3.5
				
				LocalControlSurface.AxisName = parentControlSurface.AxisName;
				LocalControlSurface.Invert = parentControlSurface.Invert;
				LocalControlSurface.MaxDeflectionDegrees = parentControlSurface.MaxDeflectionDegrees;
				LocalControlSurface.RootHingeDistanceFromTrailingEdge = parentControlSurface.RootHingeDistanceFromTrailingEdge;
				LocalControlSurface.TipHingeDistanceFromTrailingEdge = parentControlSurface.TipHingeDistanceFromTrailingEdge;
				LocalControlSurface.AffectedSections = parentControlSurface.AffectedSections;
				LocalControlSurface.Model = parentControlSurface.Model;
				LocalControlSurface.ModelRotationAxis = parentControlSurface.ModelRotationAxis;
				 
				//Keep the following unique.
				//LocalControlSurface.AxisName = previousLocalAxisName;
				LocalControlSurface.Invert = previousLocalInvert;
				LocalControlSurface.Model = previousModel;
				LocalControlSurface.ModelRotationAxis = previousRotationAxis;
			}
				
			//Copy propwash 
			PropWash parentPropWash = ParentWing.GetComponent<PropWash>();
			if (!LocalPropWash && parentPropWash )
			{
				LocalPropWash = gameObject.AddComponent<PropWash>();
			}
			if ( LocalPropWash )
			{
				Engine previousPropwashSource = LocalPropWash.PropWashSource;
				
				//Copy everything except propwash source..
				LocalPropWash.AffectedSections = parentPropWash.AffectedSections;
				LocalPropWash.PropWashSource = parentPropWash.PropWashSource;
				LocalPropWash.PropWashStrength = parentPropWash.PropWashStrength;
				
				//Keep unique
				LocalPropWash.PropWashSource = previousPropwashSource;
			}
		}
	}
#endif
}
