using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Orcs : MonoBehaviour {
	private float				speed;
	public Vector2				order_pos;
	public AudioClip 			selected;
	public AudioClip 			walk;
	public AudioClip 			attack;
	public AudioClip 			death;
	public bool					building;
	public bool					building_hq;
	public int					life_max;
	public int					life;
	public int					attack_dmg;
	public float				attack_speed;
	private float				elapsed;
	private Orcs				target;

	// Use this for initialization
	void Start () {
		if (building)
			return ;
		float randX = Random.Range(4.9f, 5.9f);
		float randY = Random.Range(0.9f, 1.9f);
		transform.position = new Vector3(randX, randY, -1f);
		order_pos = new Vector2(transform.position.x, transform.position.y);
		speed = 2f;
	}
	
	void FixedUpdate() {
		if (life <= 0)
		{
			if (building)
			{
				if (!building_hq)
					Orcs_Spawner.instance.IncreaseSpawnTime(-2.5f);
				else
					Debug.Log("The Human Team wins.");
			}
			Audio_Manager.instance.set_music(death);
			Destroy(this.gameObject);
		}
	}

	public void GetHit(int dmg) {
		life -= dmg;
		if (life < 0)
			life = 0;
		if (building)
			Debug.Log("Orc town ["+ life + "/" + life_max + "]HP has been attacked.");
		else
			Debug.Log("Orc unit ["+ life + "/" + life_max + "]HP has been attacked.");
	}

	public Orcs GetOrcs() {
		return this;
	}
}
