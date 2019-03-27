using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portail : MonoBehaviour {
	public GameObject 	son;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (son && collider.gameObject.CompareTag("Player")) {
			collider.gameObject.transform.position = son.transform.position;
		}

	}

	void OnTriggerExit2D(Collider2D collider) {
	}
}
