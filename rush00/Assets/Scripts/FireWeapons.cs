using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapons : MonoBehaviour {
	public SoundShot	soundTrigger;
	public int			ammo;
	public Bullet		bullet;
	public float		atackSpeed;
	public Sprite		equiped;
	public Sprite		unequiped;
	public bool			isEquiped;
	public bool			isDeadly;

	public SpriteRenderer		sprite;

	public bool			isFlying;
	private Vector3		flyingLocation;
	public CircleCollider2D collider;
	public AudioClip	sound;

	private bool		coolDown;

	// Use this for initialization
	void Awake () {
		collider = gameObject.GetComponent<CircleCollider2D>();
		coolDown = true;
	}

	public void Fire() 
	{
		if (ammo == 0 || !coolDown)
			return ;
		Bullet newBullet = Instantiate (bullet, transform.position - (transform.up * 0.4f), Quaternion.Euler (0, 0, transform.eulerAngles.z - 90));
		if (transform.parent.tag == "player")
		{
			if (ammo > 0)
				--ammo;
			soundTrigger.Boom();
		}
		newBullet.team = transform.parent.tag;
		StartCoroutine("CoolDown");
	}

	public void Equip() {
		collider.enabled = false;
		transform.localPosition = new Vector3(-0.15f, -0.39f, 0);
		sprite.transform.localRotation = Quaternion.identity;
		transform.localRotation = Quaternion.identity;
		sprite.sprite = equiped;
		AudioSource.PlayClipAtPoint (sound, transform.position);
		isEquiped = true;
	}

	public void Throw(Vector3 position) {
		isEquiped = false;
		transform.SetParent(null);
		collider.enabled = true;
		isFlying = true;
		flyingLocation = position;
		transform.rotation = Quaternion.identity;
		sprite.sprite = unequiped;
	}

	private void Land() {
		collider.enabled = true;
		collider.isTrigger = true;
		isFlying = false;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (isFlying && col.tag == "enemy")
		{
			if (isDeadly)
				col.gameObject.GetComponent<Enemy>().Die();
			else
				col.gameObject.GetComponent<Enemy>().Stun(1);
		}
		if (isFlying && col.tag != "player")
			Land();
	}

	private IEnumerator CoolDown()
	{
		coolDown = false;
		yield return new WaitForSeconds (1 / atackSpeed);
		coolDown = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isFlying)
		{
			if (Vector3.Distance(flyingLocation, transform.position) < 0.5f)
				Land();
			else
			{
				transform.Translate(Vector3.Normalize(flyingLocation - transform.position) * Time.deltaTime * 20);
				sprite.transform.Rotate(new Vector3(0, 0, Time.deltaTime * 900));
			}
		}
	}
}
