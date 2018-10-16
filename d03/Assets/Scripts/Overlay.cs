using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overlay : MonoBehaviour {

	[HideInInspector]public GameObject turret;
	[HideInInspector]public GameObject overlayHitBox;
	// Use this for initialization
	void Start () {
		updateOverlay();
	}
	public void Upgrade(){
		if (turret.GetComponent<towerScript>().upgrade)
		{
			if (gameManager.gm.playerEnergy >= turret.GetComponent<towerScript>().upgrade.GetComponent<towerScript>().energy)
			{
				GameObject tmp = Instantiate(turret.GetComponent<towerScript>().upgrade, turret.transform.position, turret.transform.rotation);
				gameManager.gm.playerEnergy -= turret.GetComponent<towerScript>().upgrade.GetComponent<towerScript>().energy;
				Destroy(turret);
				turret = tmp;
			}
			updateOverlay();
		}
	}
	public void Downgrade() {
		if (turret.GetComponent<towerScript>().downgrade)
		{
			GameObject tmp = Instantiate(turret.GetComponent<towerScript>().downgrade, turret.transform.position, turret.transform.rotation);
			gameManager.gm.playerEnergy += turret.GetComponent<towerScript>().energy / 2;
			Destroy(turret);
			turret = tmp;
			updateOverlay();
		}
	}
	public void Sell(){
		gameManager.gm.playerEnergy += 42;
		GameObject.Destroy(turret.gameObject);
		GameObject.Destroy(overlayHitBox);
		GameObject.Destroy(this.gameObject);
	}

	public void updateOverlay() {
		if (turret.GetComponent<towerScript>().upgrade == null)
		{
			transform.GetChild(1).gameObject.SetActive(false);
		}
		else
		{
			transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = "" + turret.GetComponent<towerScript>().upgrade.GetComponent<towerScript>().energy;
			transform.GetChild(1).gameObject.SetActive(true);
		}
		if (turret.GetComponent<towerScript>().downgrade == null)
		{
			transform.GetChild(2).gameObject.SetActive(false);
		}
		else
		{
			transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = "" + turret.GetComponent<towerScript>().energy / 2;
			transform.GetChild(2).gameObject.SetActive(true);
		}
		transform.GetChild(0).gameObject.GetComponentInChildren<Text>().text = "42";
	}

	// Update is called once per frame
	void Update () {
		
	}


}
