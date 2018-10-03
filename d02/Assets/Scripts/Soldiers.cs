using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldiers : MonoBehaviour {
	private float				speed;
	public Soldiers_Manager		manager;
	public Vector2				order_pos;
	Animator 					animator;
	private bool				idle_trigger_once;

	public AudioClip 			selected;
	public AudioClip 			walk;
	public AudioClip 			attack;

	public enum Dir
	{
		UP,
		UP_RIGHT,
		RIGHT,
		DOWN_RIGHT,
		DOWN,
		DOWN_LEFT,
		LEFT,
		UP_LEFT
	}
	public Dir	soldier_dir;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(-3.6f, 2.25f, 0f);
		// transform.position(new Vector3(-3.6f + Random.Range(-1f, 1f), 2.25f + Random.Range(-1f, 1f), 0));
		speed = 2f;
		animator = GetComponent<Animator>();
		animator.SetFloat("y", -1.0f);
		animator.SetTrigger("Idle");
		order_pos = new Vector2(transform.position.x, transform.position.y);
		idle_trigger_once = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (order_pos != new Vector2(transform.position.x, transform.position.y))
		{
			transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), order_pos, speed * Time.deltaTime);
		}
		else
		{
			if (idle_trigger_once)
			{
				idle_trigger_once = false;
				animator.SetTrigger("Idle");
			}
		}
	}

	public void Set_direction(Vector2 _order_pos)
	{
		animator.SetTrigger("Walk");
		Audio_Manager.instance.set_music(walk);
		order_pos = _order_pos;
		animator.SetFloat("x", order_pos.x - transform.position.x);
		animator.SetFloat("y", order_pos.y - transform.position.y);
		idle_trigger_once = true;
	}

	void OnMouseDown() {
		Audio_Manager.instance.set_music(selected);
		Soldiers_Manager.instance.add_soldier(this);
	}
}
