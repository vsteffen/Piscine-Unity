using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Human {
	private float			playerSpeed;
	// Use this for initialization
	void Start () {
		ParentStart();
		playerSpeed = 8f;
		maxSpeed = 8f;
	}
	
	void Update() {
		if (Time.timeScale > 0.1f)
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position) * Quaternion.Euler(0, 0, 180);
			if (Input.GetKey("mouse 0"))
				Fire();
			if (Input.GetKey("mouse 1"))
				Throw(new Vector3(mousePos.x, mousePos.y, 0));
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (Input.GetKeyDown("e") && weapon == null)
		{
			if (col.tag == "weapon")
			{
				weapon = col.gameObject.GetComponent<FireWeapons>();
				Equip();
			}
		}
	}

	void FixedUpdate () {
		if (Input.GetKey(KeyCode.W)) {
			rb.AddForce(Vector2.up * playerSpeed, ForceMode2D.Impulse);
		}
		if (Input.GetKey(KeyCode.S)) {
			rb.AddForce(Vector2.down * playerSpeed, ForceMode2D.Impulse);
		}
		if (Input.GetKey(KeyCode.A)) {
			rb.AddForce(Vector2.left * playerSpeed, ForceMode2D.Impulse);
		}
		if (Input.GetKey(KeyCode.D)) {
			rb.AddForce(Vector2.right * playerSpeed, ForceMode2D.Impulse);
		}
		if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
		{
			// rb.velocity = rb.velocity * 0.9f * Time.deltaTime;
			rb.velocity = Vector3.zero;
		}
		if (rb.velocity.Equals(Vector2.zero))
			isWalking = false;
		else
			isWalking = true;
		if (rb.velocity.magnitude > maxSpeed)
			rb.velocity = rb.velocity.normalized * maxSpeed;

		if (!isWalking)
			animator.SetBool("IsWalking", false);
		else
			animator.SetBool("IsWalking", true);

	}
}
