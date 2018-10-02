using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit_trigger : MonoBehaviour {
	public int			id;
	private static int	correct_cube;

	void Start() {
		correct_cube = 0;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (id == collider.gameObject.GetComponent<playerScript_ex00>().id)
		{
			correct_cube++;
			if (correct_cube == 3)
				Debug.Log("You won!");
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (id == collider.gameObject.GetComponent<playerScript_ex00>().id)
		{
			correct_cube--;
		}
	}
}
