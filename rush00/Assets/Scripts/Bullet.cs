using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float speed;
	public float range;
	public bool isTimed;
	public string team;
	private Vector3 start;
	public AudioClip sound;

	// Use this for initialization
	void Start () {
		if (isTimed)
			Invoke("Kill", range);
		start = transform.position;
		AudioSource.PlayClipAtPoint (sound, transform.position);
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.right.x * speed, transform.right.y * speed);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "player" || col.tag == "enemy")
		{
			if (col.tag != team)
			{
				col.gameObject.GetComponent<Human>().Die();
				GameObject.Destroy(gameObject);
			}
			else if (team != "player")
				GameObject.Destroy(gameObject);
		}
		else
			GameObject.Destroy(gameObject);
	}
	
	void Kill()
	{
		GameObject.Destroy(gameObject);
	}

	// Update is called once per frame
	void Update () {
		if (!isTimed && Vector3.Distance(transform.position, start) >= range)
			GameObject.Destroy(gameObject);
//		 .Translate(Vector3.right * speed * Time.deltaTime);		
	}
}
