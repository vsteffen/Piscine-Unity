using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex00 : MonoBehaviour {
	private Vector3			initial_pos;
	public int				id;
	private int				id_use;
	private Rigidbody2D		rb;
	public LayerMask		groundLayer;
	public bool				grounded;
	public int				grounds;
	public float			speed;

	void Start () {
		initial_pos = transform.position;
		id_use = 1;
		rb = GetComponent<Rigidbody2D>();
		grounds = 0;
	}
	
	void Update () {
		if (id > 10)
			return ;
		if (Input.GetKeyDown(KeyCode.Keypad1))
		{
			id_use = 1;
			if (id == 1)
			{
				rb.constraints = RigidbodyConstraints2D.None;
				rb.constraints = RigidbodyConstraints2D.FreezeRotation;
			}
			else
				rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
		}
		else if (Input.GetKeyDown(KeyCode.Keypad2))
		{
			id_use = 2;
			if (id == 2)
			{
				rb.constraints = RigidbodyConstraints2D.None;
				rb.constraints = RigidbodyConstraints2D.FreezeRotation;
			}
			else
				rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
		}
		else if (Input.GetKeyDown(KeyCode.Keypad3))
		{
			id_use = 3;
			if (id == 3)
			{
				rb.constraints = RigidbodyConstraints2D.None;
				rb.constraints = RigidbodyConstraints2D.FreezeRotation;
			}
			else
				rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
		}
		if (id_use == id)
		{
			if (Input.GetKey(KeyCode.Space) && grounded == true)
			{
				rb.velocity = new Vector2(rb.velocity.x, 0);
				rb.AddForce(new Vector2(0,06), ForceMode2D.Impulse);
			}
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				rb.velocity = new Vector2(0, rb.velocity.y);
				rb.AddForce(new Vector2(-100f * speed, 0));
			}
			else if (Input.GetKey(KeyCode.RightArrow))
			{
				rb.velocity = new Vector2(0, rb.velocity.y);
				rb.AddForce(new Vector2(100f * speed, 0));
			}
			else
				rb.velocity = new Vector2(0, rb.velocity.y);
		}
		if (Input.GetKeyDown(KeyCode.R))
			transform.position = initial_pos;
	}

	 void OnCollisionEnter2D(Collision2D collision) {
		if (id > 10)
			return ;
		if (collision.gameObject.CompareTag("Player"))
		{
			if (id_use != id)
				rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
		}
	 }

	void OnTriggerEnter2D(Collider2D collision) {
		if (id > 10)
		{
			if (LayerMask.LayerToName(collision.gameObject.layer) == "Platforms")
			{
				playerScript_ex00 parent = this.transform.parent.GetComponent<playerScript_ex00>();
				parent.grounds++;
				parent.grounded = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D collision) {
		if (id > 10)
		{
			if (LayerMask.LayerToName(collision.gameObject.layer) == "Platforms")
			{
				playerScript_ex00 parent = this.transform.parent.GetComponent<playerScript_ex00>();
				parent.grounds--;
				if (parent.grounds < 1)
					parent.grounded = false;
			}
		}
	}

	void OnCollisionExit2D(Collision2D collision) {
		if (id > 10)
			return ;
		else if (collision.gameObject.CompareTag("Player"))
		{
			if (id_use != id)
			{
				rb.constraints = RigidbodyConstraints2D.None;
				rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
			}
		}
	 }
}
