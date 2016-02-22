using UnityEngine;
using System.Collections;

public class SwitchObject : MonoBehaviour
{

	public bool isOn = false;
	public bool switchButton = false;
	public bool desiredState = false;
	public GameObject player;
	public GameObject objectOn;
	public GameObject objectOff;
	public float distance = 2.0f;
	// Use this for initialization
	void Start ()
	{
		updateObjects ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void updateObjects ()
	{
		if (objectOn == null || objectOff == null) {
			return;
		}

		if (isOn) {
			objectOn.SetActive (true);
			objectOff.SetActive (false);
		} else {
			objectOn.SetActive (false);
			objectOff.SetActive (true);			
		}

		if (Application.isPlaying) {
			gameObject.SendMessageUpwards ("IsDesiredState", SendMessageOptions.DontRequireReceiver);
		}
	}

	void switchObjects ()
	{
		isOn = !isOn;
		updateObjects ();
	}

	void switchOn ()
	{
		isOn = true;
		updateObjects ();
	}

	void switchOff ()
	{
		isOn = false;
		updateObjects ();
	}

	void OnValidate ()
	{
		updateObjects ();
	}

	void DoActivateTrigger ()
	{
		switchObjects ();
	}

	void OnMouseOver ()
	{
		if (player != null) {
			if (Vector3.Distance (player.transform.position, transform.position) > distance) {
				return;
			}
		}

		if (switchButton) {
			if (Input.GetKeyDown (KeyCode.Mouse1)) {
				Debug.Log ("click1");
				switchObjects ();
			}
		} else {			
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				Debug.Log ("click0");
				switchObjects ();
			}
		}
	}
}
