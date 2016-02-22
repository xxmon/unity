using UnityEngine;
using System.Collections;

public class PositionSlider : MonoBehaviour
{
	public float speed = 0.5f;
	public float slider = 0.0f;

	public Transform startMarker;
	public Transform endMarker;

	public enum Moving
	{
		Stop = 0,
		Forward = 1,
		Backward = 2
	}

	public enum Bounce
	{
		None = 0,
		Pingpong = 1,
		Return = 2
	}

	public Moving moving = Moving.Forward;
	public Bounce bounce = Bounce.None;

	// Use this for initialization
	void Start ()
	{
		SetAll ();
	}

	//
	void SetAll ()
	{
		if (speed < 0) {
			speed = 0;
		}
		slider = Mathf.Clamp (slider, 0.0f, 1.0f);

		if (startMarker == null || endMarker == null) {
			return;
		}

		transform.position = Vector3.Lerp (startMarker.position, endMarker.position, slider);
	}

	//
	void DoMovement (Moving pMoving)
	{
		moving = pMoving;

		switch (moving) {
		case Moving.Stop:
			Debug.Log ("DoStop");
			break;
		case Moving.Forward:
			Debug.Log ("DoForward");
			break;
		case Moving.Backward:
			Debug.Log ("DoBackward");
			break;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (startMarker == null || endMarker == null) {
			return;
		}

		switch (moving) {
		case Moving.Stop:
			return;
		case Moving.Forward:
			slider += speed * Time.deltaTime;
			SetAll ();
			break;
		case Moving.Backward:
			slider -= speed * Time.deltaTime;
			SetAll ();
			break;
		}

		if (slider == 0.0f || slider == 1.0f) {
			ReachedTarget ();
		}
	}

	//
	void ReachedTarget ()
	{
		Debug.Log ("ReachedTarget");

		switch (bounce) {
		case Bounce.None:
			Debug.Log ("Finish");
			DoMovement (Moving.Stop);
			break;
		case Bounce.Return:
			switch (moving) {
			case Moving.Stop:
				break;
			case Moving.Forward:
				Debug.Log ("Return");
				DoMovement (Moving.Backward);
				break;
			case Moving.Backward:
				Debug.Log ("Finish");
				DoMovement (Moving.Stop);
				break;
			}
			break;
		case Bounce.Pingpong:
			Debug.Log ("Pingpong");
			switch (moving) {
			case Moving.Stop:
				DoMovement (Moving.Stop);
				break;
			case Moving.Forward:
				DoMovement (Moving.Backward);
				break;
			case Moving.Backward:
				DoMovement (Moving.Forward);
				break;
			}
			break;
		}
	}

	//
	void OnValidate ()
	{
		SetAll ();
	}
}
