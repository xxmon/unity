using UnityEngine;
using System.Collections;

public class MovableController : MonoBehaviour
{
	public GameObject objectToMove;
	private bool setOffset = true;
	private Vector3 offset;

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit raycastHit = new RaycastHit ();

			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out raycastHit)) {
				Debug.Log ("Hit " + raycastHit.transform.gameObject.name);

				Movable movable = raycastHit.transform.gameObject.GetComponent<Movable> ();
				if (movable != null && movable.isMovable) {
					setOffset = true;
					objectToMove = movable.GetTarget ();
				}
			} 
		}

		if (Input.GetMouseButton (0)) {
			if (objectToMove != null) {
				Plane groundPlane = new Plane (Vector3.up, Vector3.zero);

				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				float rayDistance;
				if (groundPlane.Raycast (ray, out rayDistance)) {
					Vector3 hit = ray.GetPoint (rayDistance);

					if (setOffset) {
						setOffset = false;
						offset = objectToMove.transform.position - hit;
					}

					objectToMove.transform.position = hit + offset;
				}
			}
		}

		if (Input.GetMouseButtonUp (0)) {
			objectToMove = null;
		}
	}
}
