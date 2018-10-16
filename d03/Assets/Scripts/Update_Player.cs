using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Update_Player : MonoBehaviour {
	public int data;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (data == 0)
			gameObject.GetComponent<Text>().text = "" + gameManager.gm.playerHp;
		if (data == 1)
			gameObject.GetComponent<Text>().text = "" + gameManager.gm.playerEnergy;
	}
}
