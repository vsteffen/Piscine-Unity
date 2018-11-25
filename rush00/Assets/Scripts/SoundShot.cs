using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundShot : MonoBehaviour {
	private Collider2D collider;
	private int i;
	// Use this for initialization
	void Start () {
		i = 0;
		collider = gameObject.GetComponent<Collider2D>();
	}
	
	public void Boom()
	{
		collider.enabled = true;
		++i;
		Invoke("NoSound", 0.2f);
	}

	private void NoSound()
	{
		--i;
		if (i == 0)
			collider.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "enemy")
		{
			Enemy enemy = col.gameObject.GetComponent<Enemy>();
			enemy.Trigger();
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "enemy")
		{
			Enemy enemy = col.gameObject.GetComponent<Enemy>();
			enemy.Trigger();
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
