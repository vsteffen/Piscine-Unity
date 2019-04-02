using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
	private bool 	rotateWay;
	public float	speedCCTV;
	public float	angleMin;
	public float	angleMax;

	// Use this for initialization
	void Start() {
		rotateWay = false;
	}

	private void Update() 
	{
		if (rotateWay)
		{
			transform.Rotate(Vector3.down * Time.deltaTime * speedCCTV, Space.World);
			if (transform.rotation.y <= angleMin)
				rotateWay = !rotateWay;
		}
		else
		{
			transform.Rotate(Vector3.up * Time.deltaTime * speedCCTV, Space.World);
			if (transform.rotation.y > angleMax)
				rotateWay = !rotateWay;
		}
	}
}
