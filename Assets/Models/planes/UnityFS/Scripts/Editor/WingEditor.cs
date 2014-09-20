//
// UnityFS - Flight Simulation Toolkit. Copyright 2013 Chris Cheetham.
//

using UnityEditor;
     
[CustomEditor(typeof(Wing))]
public class WingEditor : Editor 
{
	private HOEditorUndoManager UndoManager = null;
	private Wing targetWing = null;
	
	private void OnEnable()
	{
		targetWing = target as Wing;
 
		// Instantiate undoManager
		UndoManager = new HOEditorUndoManager( targetWing, "Wing" );
	}
	
	public override void OnInspectorGUI() 
	{
		//Undo start..
		UndoManager.CheckUndo();
		
    	targetWing.SectionCount = EditorGUILayout.IntSlider( "Section Count", targetWing.SectionCount, 1, 10 );
		
		EditorGUILayout.Space();
		
		int widthPercent = (int)(targetWing.WingTipWidthZeroToOne * 100.0f);
		widthPercent = EditorGUILayout.IntSlider( "Wing Tip width", widthPercent, 0, 100 );
		targetWing.WingTipWidthZeroToOne = (float)widthPercent / 100.0f;
		
		int wingTipSweep = (int)(targetWing.WingTipSweep * 100.0f);
		wingTipSweep = EditorGUILayout.IntSlider( "Wing Tip Sweep", wingTipSweep, -100, 100 );
		targetWing.WingTipSweep = (float)wingTipSweep / 100.0f;
		
		int wingTipAngle = (int)(targetWing.WingTipAngle);
		wingTipAngle = EditorGUILayout.IntSlider( "Wing Tip Angle", wingTipAngle, -90, 90 );
		targetWing.WingTipAngle = (float)wingTipAngle;
		
		EditorGUILayout.Space();
		
		targetWing.Aerofoil = EditorGUILayout.ObjectField("Aerofoil", targetWing.Aerofoil, typeof(Aerofoil), true) as Aerofoil;
		
		if ( null != targetWing.Aerofoil )
		{
			targetWing.Aerofoil.CL = EditorGUILayout.CurveField( "Cl", targetWing.Aerofoil.CL );
			targetWing.Aerofoil.CD = EditorGUILayout.CurveField( "Cd", targetWing.Aerofoil.CD );
			targetWing.Aerofoil.CM = EditorGUILayout.CurveField( "Cm", targetWing.Aerofoil.CM );
		}
		else
		{
			EditorGUILayout.Space();

			EditorGUILayout.HelpBox( "No aerofoil selected using basic lift drag equations.", MessageType.Warning );
			targetWing.CDOverride = EditorGUILayout.FloatField( "CD Override", targetWing.CDOverride );
			

			
		}
		
		//Undo end..
		UndoManager.CheckDirty();
		EditorUtility.SetDirty (targetWing);
		
    }
}