using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslatePos : MonoBehaviour {
	private bool	action = false;
	private Vector3	move_pos;

	// Update is called once per frame
	void Update () {
		if (action)
			transform.position = Vector3.MoveTowards(transform.position, move_pos, 1f * Time.deltaTime);
		if (transform.position == move_pos)
			action = false;
	}

	public void SetPos(Vector3 new_pos) {
		move_pos = new_pos;
		action = true;
	}
}
