using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

	public float	str;
	public float	agi;
	public float	con;
	public float	armor;
	public float	hp;
	public float	minDmg;
	public float	maxDmg;
	public int		lvl;
	public float	xp;
	public float	money;
	public float	xp_next_lvl;

	// Use this for initialization
	void Start () {
		hp = 5 * con;
		minDmg = str / 2;
		maxDmg = minDmg + 4;
	}
	
	// Update is called once per frame
	void Update () {
		if (armor > 170f)
			armor = 170f;
		if (xp >= xp_next_lvl) {
			lvl += 1;
			xp -= xp_next_lvl;
			xp_next_lvl *= 1.5f;
		}
	}

	public float GetHit(Stats Enemy) {
		return (75 + agi - Enemy.agi);
	}

	public float GetBaseDamage() {
		return (Random.Range(minDmg, maxDmg));
	}

	public float GetRealDamage(Stats Enemy) {
		return (GetBaseDamage() * (1 - Enemy.armor/200));
	}
}
