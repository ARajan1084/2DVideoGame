using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

	public Transform target;
	public float height;

	void Update ()
	{
		var wantedPos = Camera.main.WorldToScreenPoint (target.position);
		transform.position = new Vector3 (wantedPos.x, wantedPos.y + height, wantedPos.z);
	}
}
