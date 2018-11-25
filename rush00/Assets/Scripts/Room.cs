using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
	public int id_room;
	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "player")
		{
			if (GameManager.gm.playerRoom != id_room)
			{
				GameManager.gm.playerRoom = id_room;
				foreach (Enemy enemy in GameManager.gm.triggeredEnemies)
				{
					enemy.GetPath();
				}
			}
		}
		else
			col.gameObject.GetComponent<Enemy>().id_room = id_room;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
