using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPlayer : MonoBehaviour {
	// private int head_id;
	// private int body_id;
	// private int leg_id;
	public Sprite[] sprites_head;
	public Sprite[] sprites_body;
	void Start () {
		this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites_head[Random.Range(1, 13)];
		this.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = sprites_body[Random.Range(1, 3)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
