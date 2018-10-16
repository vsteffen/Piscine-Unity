using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUpgrade : MonoBehaviour {

	bool upped = true;

	[HideInInspector]public GameObject overlay;
	private void OnMouseOver() {
		if (Input.GetMouseButtonDown(1))
		{
			overlay.SetActive(true);
			upped = false;
		}
	}
	[HideInInspector] public towerScript tower;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(1))
		{
			if (!upped)
				upped = true;
			else
				overlay.SetActive(false);
		}
	}
}
