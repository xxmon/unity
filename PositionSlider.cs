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
		transform.position = Vector3.Lerp (startMarker.position, endMarker.position, slider);
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (moving) {
		case Moving.Stop:
			break;
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
			HitTarget ();
		}
	}

	//
	void HitTarget ()
	{
		Debug.Log ("Hit target");

		switch (bounce) {
		case Bounce.None:
			moving = Moving.Stop;
			break;
		case Bounce.Return:
			Debug.Log ("return");
			switch (moving) {
			case Moving.Stop:
				break;
			case Moving.Forward:
				moving = Moving.Backward;
				break;
			case Moving.Backward:
				moving = Moving.Stop;
				break;
			}
			break;
		case Bounce.Pingpong:
			Debug.Log ("pinpong");
			switch (moving) {
			case Moving.Stop:
				moving = Moving.Stop;
				break;
			case Moving.Forward:
				moving = Moving.Backward;
				break;
			case Moving.Backward:
				moving = Moving.Forward;
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
