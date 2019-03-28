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

	public void add_soldier(Soldiers _soldier, bool rightClick) {
		if (rightClick)
		{
			if (soldiers.IndexOf(_soldier) < 0)
			{
				soldiers.Add(_soldier);
			}
		}
		else
		{
			pop_soldiers();
			soldiers.Add(_soldier);
		}
	}
	
	public void pop_soldiers() {
		soldiers.Clear();
	}

	public void set_order(Orcs target) {
		if (soldiers.Count > 0)
		{
			Vector3 click_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			foreach (Soldiers soldier in soldiers)
			{
				if (target)
				{
					Orcs actual_target = soldier.getEnemy();
					if (!actual_target || target.gameObject != actual_target.gameObject)
					{
						soldier.setEnemy(target);
						soldier.Set_direction(new Vector2(click_pos.x, click_pos.y), true);
					}
				}
				else
				{
					soldier.Set_direction(new Vector2(click_pos.x, click_pos.y), true);
					soldier.setEnemy(null);
				}
			}
		}
	}

	void Update() {
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = 10;
			Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);
			RaycastHit2D hit = Physics2D.Raycast(screenPos,Vector2.zero);
			if (hit)
			{
				if (hit.collider.gameObject.tag == "Soldier")
				{
					Soldiers _soldier = hit.collider.gameObject.GetComponent<Soldiers>();
					Audio_Manager.instance.set_music(_soldier.selected);
					add_soldier(_soldier, (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)));
				}
				else if (hit.collider.gameObject.tag == "Map")
				{
					set_order(null);
				}
				else if (hit.collider.gameObject.tag == "Orc")
				{
					set_order(hit.collider.gameObject.GetComponent<Orcs>());
				}
			}
		}
		if (Input.GetMouseButtonDown(1))
			pop_soldiers();
	}
}