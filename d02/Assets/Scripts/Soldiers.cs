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
	public bool					building;
	public bool					building_hq;
	public int					life_max;
	public int					life;
	public int					attack_dmg;
	public float				attack_speed;
	private float				elapsed;
	private Orcs				target;
	private bool				followTarget;
	private List<Orcs>			attackers = new List<Orcs>();
	private bool				underAttack;		
	private bool				targetAlive;	
	private Vector2				initialPosOrder;	

	void Start () {
		if (building)
			return ;
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
		followTarget = false;
		targetAlive = false;
	}
	
	public Soldiers GetSoldier() {
		return this;
	}

	void Update () {
		if (life <= 0)
			Destroy(this);
		if (building)
			return ;
		if (!target && targetAlive)
		{
			targetAlive = false;
			attack_trigger_once = true;
		}
		if (target && followTarget)
		{
			Set_direction(order_pos, false);
			order_pos = target.gameObject.transform.position;
		}
		transform.position = new Vector3(transform.position.x, transform.position.y, -2f);
		if (order_pos != new Vector2(transform.position.x, transform.position.y))
		{
			transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), order_pos, speed * Time.deltaTime);
			idle_trigger_once = true;
			verifAndSetAnim("Walk");
		}
		else
		{
			if (!target)
			{
				verifAndSetAnim("Idle");
			}
		}
		if (!target && !attack_trigger_once)
		{
			attack_trigger_once = true;
			elapsed = 0f;
			verifAndSetAnim("Idle");
		}
	}

	public void Set_direction(Vector2 _order_pos, bool play_music)
	{
		verifAndSetAnim("Walk");
		if (play_music)
			Audio_Manager.instance.set_music(walk);
		order_pos = _order_pos;
		animator.SetFloat("x", order_pos.x - transform.position.x);
		animator.SetFloat("y", order_pos.y - transform.position.y);
	}

	public void setEnemy(Orcs orc) {
		target = orc;
		followTarget = true;
	}

	public Orcs getEnemy() {
		return target;
	}

	void verifAndSetAnim(string anim_name) {
		if (!animator.GetCurrentAnimatorStateInfo(0).IsName(anim_name))
		{
			animator.enabled = false;
			animator.enabled = true;
			animator.SetTrigger(anim_name);
		}
	}

	void OnTriggerStay2D(Collider2D collider) {
		if (target && collider.gameObject == target.gameObject)
		{
			followTarget = false;
			targetAlive = true;
			initialPosOrder = order_pos;
			// if (order_pos != transform.position && attack_trigger_once)

			if (attack_trigger_once)
			{
				order_pos = new Vector2(transform.position.x, transform.position.y);
				attack_trigger_once = false;
				Audio_Manager.instance.set_music(attack);
			}
			verifAndSetAnim("Attack");
			elapsed += Time.deltaTime;
			if (elapsed >= attack_speed)
			{
				elapsed = elapsed % attack_speed;
				target.GetHit(attack_dmg);
			}	
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (target) {
			followTarget = true;
			attack_trigger_once = true;
			order_pos = initialPosOrder;
			targetAlive = false;
		}
	}
}
