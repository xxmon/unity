using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(Transform))]
public class TransformPlus : Editor
{
	Transform myTarget;
	
	float inch = 2.54f / 100.0f;
	float foot = 30.48f / 100.0f;

	bool showPosition = true;
	bool showRotation = true;
	bool showScale = true;

	public override  void OnInspectorGUI ()
	{
		myTarget = (Transform)target;

		showPosition = EditorGUILayout.Foldout (showPosition, "Position");
		if (showPosition) {
			myTarget.localPosition = EditorGUILayout.Vector3Field ("Meter", myTarget.localPosition);
			myTarget.localPosition = EditorGUILayout.Vector3Field ("Inch", myTarget.localPosition / inch) * inch;
			myTarget.localPosition = EditorGUILayout.Vector3Field ("Foot", myTarget.localPosition / foot) * foot;
		}

		showRotation = EditorGUILayout.Foldout (showRotation, "Rotation");
		if (showRotation) {
			myTarget.localEulerAngles = EditorGUILayout.Vector3Field ("Rotation", myTarget.localEulerAngles);
		}

		showScale = EditorGUILayout.Foldout (showScale, "Scale");
		if (showScale) {
			myTarget.localScale = EditorGUILayout.Vector3Field ("Meter", myTarget.localScale);
			myTarget.localScale = EditorGUILayout.Vector3Field ("Inch", myTarget.localScale / inch) * inch;
			myTarget.localScale = EditorGUILayout.Vector3Field ("Foot", myTarget.localScale / foot) * foot;
		}
	}
}
