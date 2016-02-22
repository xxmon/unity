using UnityEngine;
using System.Collections;

public class ConstantRotation : MonoBehaviour
{
	public bool local = true;
	public Vector3 speed;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (local) {
			transform.Rotate (speed * Time.deltaTime);
		} else {
			transform.Rotate (speed * Time.deltaTime, Space.World);
		}
	}
}
