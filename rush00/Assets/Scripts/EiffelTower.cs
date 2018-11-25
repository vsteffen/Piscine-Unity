using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EiffelTower : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localScale.x >= 1.5)
			transform.localScale = Vector3.zero;
		transform.localScale = new Vector3(transform.localScale.x + 0.5f * Time.deltaTime, transform.localScale.y + 0.5f * Time.deltaTime, 1);
		
	}
}
