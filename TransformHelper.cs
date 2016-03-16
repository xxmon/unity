using UnityEngine;
using System.Collections;
	
public class TransformHelper : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetPosition(Transform newPosition)
	{
		transform.position = newPosition.position;
	}

	public void SetLocalPosition(Transform newPosition)
	{
		transform.localPosition = newPosition.position;
	}

	public void SetAllChildrenActive(bool value)
	{
		for(int i=0; i<transform.childCount; i++)
		{
			transform.GetChild(i).gameObject.SetActive(value);
		}
	}

	public void Duplicate(bool asRoot = false)
	{
		GameObject instance = Instantiate (gameObject);

		if(!asRoot)
		{
			instance.transform.SetParent (transform.parent);
		}

		instance.transform.position = transform.position;
	}
}
