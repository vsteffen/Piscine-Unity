using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldiers : MonoBehaviour {
	private float				speed;
	public Soldiers_Manager		manager;
	public Vector2				order_pos;
	Animator 					animator;
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
		speed = 3f;
		animator = GetComponent<Animator>();
		animator.SetFloat("y", -1.0f);
		animator.SetTrigger("Idle");
		order_pos = new Vector2(transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		if (order_pos != new Vector2(transform.position.x, transform.position.y))
		{
			Debug.Log(order_pos + " | " + new Vector2(transform.position.x, transform.position.y));
			transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), order_pos, speed * Time.deltaTime);
		}
		else
		{
			animator.SetTrigger("Idle");
		}
	}

	public void Set_direction(Vector2 _order_pos)
	{
		animator.SetTrigger("Walk");
		order_pos = _order_pos;
		animator.SetFloat("x", order_pos.x - transform.position.x);
		animator.SetFloat("y", order_pos.y - transform.position.y);
	}

	void OnMouseDown() {
		Soldiers_Manager.instance.set_soldier(this);
	}
}
