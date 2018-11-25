using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour {
	public bool				isWalking;
	public FireWeapons		weapon;
	public float			maxSpeed;
	public Rigidbody2D		rb;
	public Animator			animator;
	public List<AudioClip>	deathSounds;


	protected void ParentStart() {
		rb = GetComponent<Rigidbody2D>();
		if (weapon != null)
			Equip();
	}

	protected void Equip() {
		weapon.transform.SetParent(transform);
		weapon.Equip();
	}

	virtual public void Die() {
		if (tag != "player")
		{
			AudioSource.PlayClipAtPoint (deathSounds[Random.Range(0, deathSounds.Count)], transform.position);
			Destroy(gameObject);
		}
		else
		{
			gameObject.SetActive(false);
			GameManager.gm.DeathMenu();
		}
	}

	protected void Throw(Vector3 position) {
		if (weapon)
		{
			weapon.Throw(position);
			weapon = null;
		}
	}

	protected void Fire() {
		if (weapon)
			weapon.Fire();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
