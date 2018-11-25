using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletUI : MonoBehaviour {

	public Text text1;
	public Text text2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.gm.player.weapon == null)
		{
			text1.text = "-";
			text2.text = "-";
			return ;
		}
		int ammo = GameManager.gm.player.weapon.ammo;
		if (ammo < 0)
		{
			text1.text = "-";
			text2.text = "-";
		}
		else
		{

			text1.text = "" + ammo;
			text2.text = "" + ammo;
		}
	}
}
