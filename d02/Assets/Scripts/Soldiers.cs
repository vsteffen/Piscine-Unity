using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Soldiers : MonoBehaviour {
	private float				speed;
	public Vector2				order_pos;
	Animator 					animator;
	private bool				idle_trigger_once;
	private bool				attack_trigger_once;
	public AudioClip 			selected;
	public AudioClip 			walk;
	public AudioClip 			attack;
	public int					life;
	public int					attack_dmg;
	public float				attack_speed;
	private float				elapsed;
	private Orcs				target;
	private List<Orcs>			attackers = new List<Orcs>();
	private bool				underAttack;		

	void Start () {
		float randX = Random.Range(-4.1f, -3.1f);
		float randY = Random.Range(1.7f, 2.7f);
		transform.position = new Vector2(randX, randY);
		order_pos = new Vector2(transform.position.x, transform.position.y);
		speed = 2f;
		animator = GetComponent<Animator>();
		animator.SetFloat("y", -1.0f);
		animator.SetTrigger("Idle");
		idle_trigger_once = false;
		attack_trigger_once = true;
		underAttack = false;
	}
	
	public Soldiers GetSoldier() {
		return this;
	}

	void Update () {
		if (life <= 0)
			Destroy(this);
		transform.position = new Vector3(transform.position.x, transform.position.y, -2f);
		if (order_pos != new Vector2(transform.position.x, transform.position.y))
		{
			transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), order_pos, speed * Time.deltaTime);
			idle_trigger_once = true;
		}
		else
		{
			if (idle_trigger_once)
			{
				animator.SetTrigger("Idle");
				idle_trigger_once = false;
			}
		}
		if (!target && !attack_trigger_once)
		{
			attack_trigger_once = true;
			elapsed = 0f;
			animator.SetTrigger("Idle");
		}
	}

	public void Set_direction(Vector2 _order_pos)
	{
		animator.SetTrigger("Walk");
		Audio_Manager.instance.set_music(walk);
		order_pos = _order_pos;
		animator.SetFloat("x", order_pos.x - transform.position.x);
		animator.SetFloat("y", order_pos.y - transform.position.y);
	}

	public void setEnemy(Orcs orc) {
		target = orc;
	}	

	void OnTriggerStay2D(Collider2D collider) {
		if (target && collider.gameObject == target.gameObject)
		{
			Debug.Log("Attack ANIM" + attack_trigger_once);
			if (attack_trigger_once)
			{
				Debug.Log("Attack ANIM");
				transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, transform.position.y), speed * Time.deltaTime);
				attack_trigger_once = false;
				animator.SetTrigger("Attack");
			}
			elapsed += Time.deltaTime;
			if (elapsed >= attack_speed)
			{
				elapsed = elapsed % attack_speed;
				target.GetHit(attack_dmg);
			}	
		}
	}
}
