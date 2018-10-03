using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldiers_Manager : MonoBehaviour {
	public static Soldiers_Manager	instance { get; private set;}
	Soldiers 				soldier;
	public List<Soldiers>	soldiers = new List<Soldiers>();

	void Awake() {
		instance = this;
	}

	public void add_soldier(Soldiers _soldier) {
		Debug.Log("Soldier set in manager");
		soldiers.Add(_soldier);
	}
	
	void pop_soldiers() {
		Debug.Log("Soldier set in manager");
		// soldiers.Pop(_soldier);
		soldiers.Clear();
	}

	void Update() {

	}

	void OnMouseDown() {
		if (soldiers.Count > 0)
		{
			Vector3 click_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			foreach (Soldiers soldier in soldiers)
			{
				soldier.Set_direction(new Vector2(click_pos.x, click_pos.y));
			}
			pop_soldiers();
		}
	}
}