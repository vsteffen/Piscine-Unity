using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
	public GameObject	action;

	void OnTriggerEnter2D(Collider2D collider) {
		if (action && collider.gameObject.CompareTag("Player")) {
			Destroy(action);
			Destroy(gameObject);
		}

	}

}
