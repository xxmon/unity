using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[System.Serializable]
public class Movable : MonoBehaviour
{
	public GameObject objectToMove;
	public bool moveRelativeToTransform;
	public GameObject target;
	public Vector3 start;
	public Vector3 offset;
	public bool updateOffset;
	public bool isMoving;

	[SerializeField]
	public UnityEvent doOnPickUp;
	[SerializeField]
	public UnityEvent doOnMouseGrab;
	[SerializeField]
	public UnityEvent doOnDrop;
	[SerializeField]
	public UnityEvent doOnMouseOver;

	public bool firstInstance = true;

	public void ResetUnityEvents()
	{
		doOnPickUp = new UnityEvent ();
		doOnMouseGrab = new UnityEvent ();
		doOnDrop = new UnityEvent ();
		doOnMouseOver = new UnityEvent ();		
	}

	void Awake ()
	{
		
	}

	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{
		isMoving = false;

		if (Input.GetMouseButtonDown (0)) {
			if (target != null) {
				start = target.transform.position;
			}
		}

		if (Input.GetMouseButtonUp (0)) {
			if (target != null) {
				//Align (target);
				doOnDrop.Invoke ();
			}
			target = null;
		}
	}

	void OnMouseDrag ()
	{
		isMoving = true;

		Plane groundPlane;

		if (moveRelativeToTransform) {
			groundPlane = new Plane (Vector3.up, target.transform.position);
		} else {
			groundPlane = new Plane (Vector3.up, Vector3.zero);
		}

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float rayDistance;
		if (groundPlane.Raycast (ray, out rayDistance)) {
			if (updateOffset) {
				offset = target.transform.position - ray.GetPoint (rayDistance);
				updateOffset = false;
			}

			target.transform.position = ray.GetPoint (rayDistance) + offset;
		}

		doOnMouseGrab.Invoke ();
	}

	void OnMouseOver ()
	{
		doOnMouseOver.Invoke ();

		if (Input.GetMouseButtonDown (0)) {
			if (target == null) {
				if (objectToMove == null) {
					objectToMove = transform.gameObject;
				}

				target = objectToMove;
				start = target.transform.position;
				updateOffset = true;

				doOnPickUp.Invoke ();
			}
		}
	}

	public void ResetPosition ()
	{
		transform.position = start;
	}
}
