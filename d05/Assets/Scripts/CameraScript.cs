using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
	public GameObject to_follow;
	public Vector3 _offset;

	void Start()
	{
		// _offset = new Vector3(-50f, 50f, 10); // or whatever you need
	}

	void FixedUpdate()
	{
		transform.position = to_follow.transform.position + _offset;
		transform.LookAt(to_follow.transform.position);
	}
}
