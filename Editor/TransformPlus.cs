using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(Transform))]
public class TransformPlus : Editor
{
	Transform myTarget;
	float inch = 2.54f;
	float foot = 30.48f;

	public override  void OnInspectorGUI ()
	{
		myTarget = (Transform)target;

		myTarget.localPosition = EditorGUILayout.Vector3Field ("Position", myTarget.localPosition);
		EditorGUILayout.Vector3Field ("Position (inch)", myTarget.localPosition / inch);
		EditorGUILayout.Vector3Field ("Position (foot)", myTarget.localPosition / foot);

		myTarget.localEulerAngles = EditorGUILayout.Vector3Field ("Rotation", myTarget.localEulerAngles);

		myTarget.localScale = EditorGUILayout.Vector3Field ("Scale", myTarget.localScale);
		EditorGUILayout.Vector3Field ("Scale (inch)", myTarget.localScale / inch);
		EditorGUILayout.Vector3Field ("Scale (foot)", myTarget.localScale / foot);
	}
}
