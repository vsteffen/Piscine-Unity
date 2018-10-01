using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {
	// Vector3 scale;
	private int		breath;
	private float 	elapsed;

	// Use this for initialization
	void Start () {
		transform.localScale += new Vector3(6, 6, 0);
		breath = 3;
		elapsed = 0f;
	}
	
	void gameover() {
		GameObject.Destroy(this);
		Debug.Log("Ballon life time: " + Mathf.RoundToInt(Time.time) + "s");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && breath > 0)
        {
			breath -= 1;
			transform.localScale += new Vector3(1F, 1F, 0);
        }
		else
		{
			transform.localScale += new Vector3(-0.05F, -0.05F, 0);
		}
		Vector3 scale = transform.localScale;
		if (scale.x <= 0.2 || scale.x >= 9)
			gameover();
		elapsed += Time.deltaTime;
		if (elapsed >= 0.3f)
		{
        	elapsed = elapsed % 0.3f;
			if (breath < 3)
			{
				breath++;
			}
		}
	}
}
