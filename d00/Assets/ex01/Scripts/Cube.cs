using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
	private float	speed;

	public KeyCode key;

	// Use this for initialization
	void Start () {
		speed = Random.Range(8f, 12f);
	}
	
	void die() {
		GameObject.Destroy(this.gameObject);
		Debug.Log("Precision: " + (4.2f + transform.position.y));
	}

	void miss() {
		GameObject.Destroy(this.gameObject);
		Debug.Log("Miss cube!");
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
		else if (transform.position.y < -4.2f)
			miss();
	}
}
