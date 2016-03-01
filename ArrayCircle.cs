using UnityEngine;
using System.Collections;
using UnityEditor;

public class ArrayCircle : MonoBehaviour
{
	public GameObject target;
	public int numberToSpawn = 9;
	public float radius = 2f;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void DoShape ()
	{
		if(target == null)
		{
			return;
		}
		float theta = 360f / numberToSpawn;
		float step = theta;


		for (int i = 0; i < numberToSpawn; i++) {
			float x = 0f;
			float y = transform.position.y;
			float z = 0f;

			x = transform.position.x + radius * Mathf.Cos (theta * Mathf.PI / 180);
			z = transform.position.z + radius * Mathf.Sin (theta * Mathf.PI / 180);

			GameObject clone;
			clone = Instantiate(target, new Vector3(x,y,z), Quaternion.identity) as GameObject;
			clone.transform.SetParent (gameObject.transform);
			theta += step;
		}
	}
}


[CustomEditor(typeof(ArrayCircle))]
public class ArrayCircleEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		ArrayCircle myScript = (ArrayCircle)target;
		if(GUILayout.Button("Build Objects"))
		{
			myScript.DoShape();
		}
	}
}
