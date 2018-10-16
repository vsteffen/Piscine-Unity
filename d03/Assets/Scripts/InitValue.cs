using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitValue : MonoBehaviour {
	public GameObject turret;
	public int data;
	private Color red;
	private Color white;
	// Use this for initialization
	void Start () {
		red = new Color(1, 0, 0, 1);
		white = new Color(1, 1, 1, 1);
		if (data == 0)
			gameObject.GetComponent<Text>().text = "" + turret.GetComponent<towerScript>().fireRate;
		if (data == 1)
			gameObject.GetComponent<Text>().text = "" + turret.GetComponent<towerScript>().damage;
		if (data == 2)
			gameObject.GetComponent<Text>().text = "" + turret.GetComponent<towerScript>().energy;
		if (data == 3)
			gameObject.GetComponent<Text>().text = "" + turret.GetComponent<towerScript>().range;

	}
	
	// Update is called once per frame
	void Update () {
		if (data == 4) {
			if (gameManager.gm.playerEnergy < turret.GetComponent<towerScript>().energy)
				GetComponent<Image>().color = red;
			if (gameManager.gm.playerEnergy >= turret.GetComponent<towerScript>().energy)
				GetComponent<Image>().color = white;
		}
	}
}
