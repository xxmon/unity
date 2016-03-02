using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MeshRenderer))]

public class HideAtStart : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		if (Application.isPlaying) {
			GetComponent<MeshRenderer> ().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
