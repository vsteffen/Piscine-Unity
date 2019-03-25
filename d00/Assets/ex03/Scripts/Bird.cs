using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
	public float	speed;
	public float	minPosY;
	public float	maxPosY;
	private float	jump;

	// Use this for initialization
	void Start () {
		jump = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (jump >= 0f)
		{
			transform.Translate(Vector3.up * Time.deltaTime * speed);
			jump -= Time.deltaTime;
		}
		else
			transform.Translate(Vector3.down * Time.deltaTime * speed);
		if (jump < 0f && Input.GetKey(KeyCode.Space) && maxPosY > transform.position.y)
			jump = 0.5f;
	}
}
