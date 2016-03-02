using UnityEngine;
using System.Collections;
using UnityEditor;

public class ArrayLine : MonoBehaviour {

	public GameObject target;
	public int numberToSpawn = 8;
	public Vector3 space;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}	

	public void Reposition ()
	{
		for (int i = 0; i < transform.childCount; ++i) {
			transform.GetChild (i).transform.localPosition = space*i;
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

		Reposition ();
	}
}

[CustomEditor (typeof(ArrayLine))]
public class ArrayLineEditor : Editor
{
	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector ();

		ArrayLine myScript = (ArrayLine)target;
		if (GUILayout.Button ("Reset")) {
			myScript.SpawnChildren ();
			myScript.Reposition ();
		}
	}
}
