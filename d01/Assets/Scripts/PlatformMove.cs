using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour {
	public bool		move;
	public float	maxStart;
	public float	maxEnd;
	public bool		dir;
	public float	speed;
	private Rigidbody2D		rb;
	private Vector2	vec;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		vec = new Vector2(0, speed);
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (move) // horizontally
		{
			if ((dir && transform.position.x >= maxEnd) || (!dir && transform.position.x <= maxStart))
			{
				dir = !dir;
				if (dir)
					vec = new Vector2(speed, 0);
				else
					vec = new Vector2(-speed, 0);
			}
		}
		else // vertically
		{
			if ((dir && transform.position.y >= maxEnd) || (!dir && transform.position.y <= maxStart))
			{
				dir = !dir;
				if (dir)
					vec = new Vector2(0, speed);
				else
					vec = new Vector2(0, -speed);
			}
		}
		rb.velocity = vec;
	}
}
