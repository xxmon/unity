using UnityEngine;
using System.Collections;

public class SwitchObject : MonoBehaviour
{

	public bool on = false;
	public GameObject objectOn;
	public GameObject objectOff;
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

		if (on) {
			objectOn.SetActive (true);
			objectOff.SetActive (false);
		} else {
			objectOn.SetActive (false);
			objectOff.SetActive (true);			
		}
	}

	void switchObjects ()
	{
		on = !on;
		updateObjects ();
	}

	void switchOn ()
	{
		on = true;
		updateObjects ();
	}

	void switchOff ()
	{
		on = false;
		updateObjects ();
	}

	void OnValidate ()
	{
		updateObjects ();
	}
}
