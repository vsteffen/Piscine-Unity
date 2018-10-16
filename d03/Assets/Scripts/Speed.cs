using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speed : MonoBehaviour {

	public GameObject text;

	// Use this for initialization
	void Start () {
		ChangeSpeed(0);
	}
	
	public void ChangeSpeed(int speed_id){
		// print(speed_id);
		gameManager.gm.changeSpeed(speed_id);
		text.GetComponent<Text>().text = "Speed : " + speed_id;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
