using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
	public float	speed;
	public float	minPosY;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space))
			transform.Translate(Vector3.up * Time.deltaTime * speed);
		else
			transform.Translate(Vector3.down * Time.deltaTime * speed);
		// if (transform.position.y)
	}
}
