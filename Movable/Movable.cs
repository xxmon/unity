using UnityEngine;

[System.Serializable]
public class Movable : MonoBehaviour
{
	public GameObject target;
	public bool isMovable = true;

	public GameObject GetTarget ()
	{
		if (target == null) {
			return gameObject;
		} else {
			return target;
		}
	}
}
