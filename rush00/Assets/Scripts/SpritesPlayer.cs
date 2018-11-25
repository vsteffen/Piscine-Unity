using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesPlayer : MonoBehaviour {
	public int			id;

	void Start() {
		if (id == 1) // HEAD
			transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
		else if (id == 3) // HEAD
			transform.position = new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z);			
	}

	void Update () {


	}
}
