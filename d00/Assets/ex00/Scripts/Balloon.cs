using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballon_inflate : MonoBehaviour {
	// Vector3 theScale;

	// Use this for initialization
	void Start () {
		// theScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
			transform.localScale += new Vector3(0.1F, 0.1f, 0);
			Debug.Log(transform.localScale);
        }	
	}
}
