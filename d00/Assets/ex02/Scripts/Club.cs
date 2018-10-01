using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour {
	public Ball			ball;
	private float		pow;
	private bool		in_use;
	private	Vector3		old_pos;
	private bool		dir_up;

	// Use this for initialization
	void Start () {
		pow = 0;
		in_use = false;
		old_pos = transform.position;
		dir_up = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space) && transform.position.y != 100f)
		{
			in_use = true;
			if (pow < 0.6f)
				pow += 0.01f;
			transform.Translate(Vector3.down * Time.deltaTime * 2);
		}
		else
		{
			if (in_use == true)
			{
				transform.position = old_pos;
				in_use = false;
				ball.set_pow(pow);
				pow = 0f;
			}
		}
	}

	public void set_pos(float pos_y, bool dir_up) {
		if (transform.position.y == 100f)
			return ;
		if (this.dir_up != dir_up)
		{
			transform.localRotation = Quaternion.Euler(180, 180, 0);
			transform.position = new Vector3(transform.position.x, pos_y, transform.position.z);
		}
		else
		{
			transform.localRotation = Quaternion.Euler(0, 0, 0);
			transform.position = new Vector3(transform.position.x, pos_y, transform.position.z);
		}
	}
}
