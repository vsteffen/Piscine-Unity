using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Human {
	public bool 			isTriggered;
	public Checkpoint 		targetCP;
	public ViewEnemy 		view;
	public int 				id_room;
	public List<Checkpoint>	path;
	public bool				isStun;
	public SpriteRenderer	headSprite;
	public Patrol			patrol;

	// Use this for initialization
	void Start () {
		isTriggered = false;
		isStun = false;
		weapon = GameManager.gm.GetRandomWeapon();
		ParentStart();
	}

	public void Stun(float time)
	{
		StartCoroutine (TimerStun (time));
	}

	private IEnumerator TimerStun (float time)
	{
		isStun = true;
		for (float f = 0; f < time; f += 0.5f) {
			headSprite.color = Color.gray;
			yield return new WaitForSeconds (0.25f);
			headSprite.color = Color.white;
			yield return new WaitForSeconds (0.25f);
		}
		Trigger();
		isStun = false;
	}

	private Checkpoint findClosest(List<Checkpoint> cps)
	{
		float dist = -1;
		Checkpoint closest = null;
		foreach (Checkpoint cp in cps)
		{
			float newDist = Vector3.Distance(transform.position, cp.transform.position);
			if (dist < 0 || newDist < dist)
			{
				dist = newDist;
				closest = cp;
			}
		}
		return closest;
	}

	public void GetPath()
	{
		List<Checkpoint> cps = GameManager.gm.checkpoints.FindAll(s => s.id_room == id_room);
		targetCP = findClosest(cps);
		path = GameManager.gm.pathfinder.GetPath(targetCP, GameManager.gm.playerRoom);
	}

	public void Trigger()
	{
		if (!isTriggered)
		{
			GetPath();
			isTriggered = true;
			GameManager.gm.triggeredEnemies.Add(this);
			Destroy(view.gameObject);
		}
	}



	override public void Die() {
		AudioSource.PlayClipAtPoint (deathSounds[Random.Range(0, deathSounds.Count)], transform.position);
		GameManager.gm.triggeredEnemies.Remove(this);
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (isTriggered && !isStun)
		{
			transform.rotation = Quaternion.LookRotation(Vector3.forward, GameManager.gm.player.transform.position - transform.position) * Quaternion.Euler(0, 0, 180);
			if (id_room == GameManager.gm.playerRoom)
			{
				Fire();
				Vector3 vector = Vector3.Normalize(GameManager.gm.player.transform.position - transform.position);
				gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (vector.x * 1000, vector.y * 1000);
			}
			else
			{
				if (Vector3.Distance(targetCP.transform.position, transform.position) < 1f)
				{
					path.Remove(targetCP);
					targetCP = path[0];
					return ;
				}
				else
				{
					Vector3 vector = Vector3.Normalize(targetCP.transform.position - transform.position);
					gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (vector.x * 1000, vector.y * 1000);
	//				transform.Translate(Vector3.Normalize(targetCP.transform.position - transform.position) * Time.deltaTime * 5);
				}
				RaycastHit2D hit = Physics2D.Raycast(transform.position, GameManager.gm.player.transform.position - transform.position, 1000, 1 << LayerMask.NameToLayer("Player") | 1 << LayerMask.NameToLayer("Wall"));
				if (hit.collider.tag == "player")
					Fire();
			}
		}
		else if (patrol)
		{
			if (Vector3.Distance(patrol.transform.position, transform.position) < 0.5f)
				patrol = patrol.next;
			Vector3 vector = Vector3.Normalize(patrol.transform.position - transform.position);
			transform.rotation = Quaternion.LookRotation(Vector3.forward, patrol.transform.position - transform.position) * Quaternion.Euler(0, 0, 180);
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (vector.x * 1000, vector.y * 1000);
		}
	}
}
