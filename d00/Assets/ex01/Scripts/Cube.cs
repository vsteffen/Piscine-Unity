using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
	private float	speed;

	public KeyCode		key;

	// Use this for initialization
	void Start () {
		speed = Random.Range(7f, 13f);
	}
	
	void die() {
		float dist = (-4.0f - transform.position.y);
		if (dist < 0)
			dist = -dist;
		Debug.Log("Precision: " + dist);
		GameObject.Destroy(this.gameObject);
	}

	void miss() {
		Debug.Log("Miss cube!");
		GameObject.Destroy(this.gameObject);
	}

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.down * Time.deltaTime * speed);
		if (Input.GetKeyDown(KeyCode.A) && key == KeyCode.A)
			die();
		else if (Input.GetKeyDown(KeyCode.S) && key == KeyCode.S)
			die();
		else if (Input.GetKeyDown(KeyCode.D) && key == KeyCode.D)
			die();
		else if (transform.position.y < -6f)
			miss();
	}
}
