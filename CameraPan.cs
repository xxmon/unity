using UnityEngine;
using System.Collections;

public class CameraPan : MonoBehaviour {
	public Vector3 lastPosition;
	public Vector3 startPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	Vector3 CursorWorldPosition()
	{
		Vector3 position = new Vector3();

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float rayDistance;
		Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

		if (groundPlane.Raycast (ray, out rayDistance)) {
			position = ray.GetPoint (rayDistance);
		}

		return position;
	}

	// Update is called once per frame
	void Update ()
	{
		Vector3 offset = new Vector3();
		bool updateOffset = false;

		if (Input.GetMouseButtonDown (2)) {
			startPosition = CursorWorldPosition();
			lastPosition = CursorWorldPosition();
		}

		if (Input.GetMouseButton (2)) {
			Vector3 delta = CursorWorldPosition() - lastPosition;

			transform.position -= delta;
			lastPosition = CursorWorldPosition();
		}
	}
}
