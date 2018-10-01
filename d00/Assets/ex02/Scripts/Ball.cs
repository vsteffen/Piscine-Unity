using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	private float	pow;
	private bool	dir_up;
	private bool	moving;
	public Club		club;
	private int		score;

	// Use this for initialization
	void Start () {
		pow = 0f;
		dir_up = true;
		moving = false;
		score = -15;
	}
	
	void is_in_hole() {
		if (transform.position.y <= 2.5f && transform.position.y >= 2.3f && pow < 0.01f)
		{
			Debug.Log("Score: " + score);
			transform.position = new Vector3(100f, 0f, 0f);
			club.set_pos(100f, dir_up);
		}
	}

	// Update is called once per frame
	void Update () {
		if (pow > 0)
		{
			if (dir_up == true)
			{
				if (transform.position.y >= 3.66f)
				{
					transform.Translate(Vector3.down * pow);
					dir_up = false;
				}
				else
					transform.Translate(Vector3.up * pow);
			}
			else
			{
				if (transform.position.y <= -3.63f)
				{
					transform.Translate(Vector3.up * pow);
					dir_up = true;
				}
				else
				{
					transform.Translate(Vector3.down * pow);
				}
			}
			is_in_hole();
			pow -= 0.005f;
		}
		else
		{
			if (moving == true)
			{
				moving = false;
				if (transform.position.y >= 2.5f && dir_up == true)
					dir_up = false;
				else if (transform.position.y <= 2.3f && dir_up == false)
					dir_up = true;
				club.set_pos(transform.position.y, dir_up);
				is_in_hole();
				score += 5;
			}
		}
	}

	public void set_pow (float pow) {
		if (moving == false)
		{
			this.pow = pow;
			moving = true;
		}
	}
}
