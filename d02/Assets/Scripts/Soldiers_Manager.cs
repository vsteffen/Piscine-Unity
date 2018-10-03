using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldiers_Manager : MonoBehaviour {
	public static Soldiers_Manager	instance { get; private set;}
	Soldiers 		soldier;
	private bool	handle;

	void Awake() {
		instance = this;
		handle = false;
	}

	public void set_soldier(Soldiers _soldier) {
		Debug.Log("Soldier set in manager");
		handle = true;
		soldier = _soldier;
	}
	
	void Update() {

	}

	void OnMouseDown() {
		if (handle == true)
		{
			Vector3 click_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			soldier.Set_direction(new Vector2(click_pos.x, click_pos.y));
			handle = false;
		}
	}
}