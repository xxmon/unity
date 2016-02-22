using UnityEngine;
using System.Collections;

public class SwitchGroup : MonoBehaviour {
	public GameObject[] switches;
	public GameObject triggerTarget;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnValidate()
	{
		for(int i=0; i < switches.Length; i++)
		{
			if (switches [i] == null) {
				Debug.LogError ("Missing switch.");
				return;
			}

			SwitchObject obj = switches [i].GetComponent<SwitchObject>();
			if (obj == null) {
				Debug.LogError ("Missing switch.");
				return;
			}
		}
	}

	bool IsDesiredState()
	{
		for(int i=0; i < switches.Length; i++)
		{
			if (switches [i] == null) {
				Debug.LogError ("Missing switch.");
				return false;
			}

			SwitchObject obj = switches [i].GetComponent<SwitchObject>();
			if (obj == null) {
				Debug.LogError ("Missing switch.");
				return false;
			}

			if (obj.desiredState != obj.isOn) {
				return false;
			}
		}

		if(triggerTarget != null)
		{
			triggerTarget.SendMessage ("DoActivateTrigger", SendMessageOptions.DontRequireReceiver);
		}

		Debug.Log("IsDesiredState");

		return true;		
	}
}
