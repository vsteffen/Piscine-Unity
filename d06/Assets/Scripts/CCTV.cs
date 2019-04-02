using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTV : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("HEY TOI !");
		SliderControl.sld.playerVisible++;
	}

	void OnTriggerExit(Collider other)
	{
		SliderControl.sld.playerVisible--;
	}
}
