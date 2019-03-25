using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {
	public float 	speed;
	public float	repeatPos;
	private Vector3	initialPos;

	// Use this for initialization
	void Start () {
		initialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// transform.position = new Vector3(speed, 0f, 0f);
		transform.Translate(Vector3.left * Time.deltaTime * speed);
		if (repeatPos > transform.position.x)
			transform.position = initialPos;
	}
}
