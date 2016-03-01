using UnityEngine;
using System.Collections;
using UnityEditor;

public class ArrayCircle : MonoBehaviour
{
	public GameObject target;
	public int numberToSpawn = 8;
	public float radius = 2f;
	public bool doRotation = false;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void Reposition ()
	{
		float theta = 360f / transform.childCount;
		float step = theta;

		for (int i = 0; i < transform.childCount; ++i) {
			float x = 0f;
			float y = transform.position.y;
			float z = 0f;

			x = radius * Mathf.Cos (theta * Mathf.PI / 180);
			z = radius * Mathf.Sin (theta * Mathf.PI / 180);

			transform.GetChild (i).transform.localPosition = new Vector3 (x, y, z);

			if (doRotation) {
				transform.GetChild (i).localRotation = Quaternion.identity;
				transform.GetChild (i).transform.Rotate (new Vector3 (0, -theta, 0));
			} else {
				transform.GetChild (i).localRotation = Quaternion.identity;
			}

			theta += step;
		}
	}

	public void SpawnChildren ()
	{
		if (target == null) {
			return;
		}

		while (transform.childCount > 0) {
			DestroyImmediate (transform.GetChild (0).gameObject);
		}

		for (int i = 0; i < numberToSpawn; ++i) {
			GameObject clone;
			clone = Instantiate (target, Vector3.zero, Quaternion.identity) as GameObject;
			clone.transform.SetParent (gameObject.transform);
			clone.name = i.ToString ();
		}
	}

	void OnValidate ()
	{
		if (target == null) {
			return;
		}

		if (numberToSpawn < 1) {
			numberToSpawn = 1;
		}

		if (radius < 0) {
			radius = 0;
		}

		Reposition ();
	}
}


[CustomEditor (typeof(ArrayCircle))]
public class ArrayCircleEditor : Editor
{
	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector ();

		ArrayCircle myScript = (ArrayCircle)target;
		if (GUILayout.Button ("Reset")) {
			myScript.SpawnChildren ();
			myScript.Reposition ();
		}
	}
}
