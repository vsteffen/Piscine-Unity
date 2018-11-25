using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewEnemy : MonoBehaviour {
	public Enemy enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, col.transform.position - transform.position, LayerMask.NameToLayer("Player") | LayerMask.NameToLayer("Enemy") | LayerMask.NameToLayer("Wall"));
		if (hit.collider.tag == "player")
			enemy.Trigger();
	}
	
	void OnTriggerStay2D(Collider2D col)
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, col.transform.position - transform.position, 1000, 1 << LayerMask.NameToLayer("Player") | 1 << LayerMask.NameToLayer("Wall"));
		if (hit.collider.tag == "player")
			enemy.Trigger();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
