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
	public int					life;
	public int					attack_dmg;
	public float				attack_speed;
	private float				elapsed;
	private Orcs				target;

	// Use this for initialization
	void Start () {
		float randX = Random.Range(4.9f, 5.9f);
		float randY = Random.Range(0.9f, 1.9f);
		transform.position = new Vector2(randX, randY);
		order_pos = new Vector2(transform.position.x, transform.position.y);
		speed = 2f;
	}
	
	void Update() {
		if (life <= 0)
			Destroy(this);
	}

	public void GetHit(int dmg) {
		life -= dmg;
	}

	public Orcs GetOrcs() {
		return this;
	}
}
