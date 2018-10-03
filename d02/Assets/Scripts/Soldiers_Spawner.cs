using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldiers_Spawner : MonoBehaviour {
	public Soldiers		soldier;
	private float 		elapsed;

	// Use this for initialization
	void Start () {
		elapsed = 0f;
	}
	// Update is called once per frame
	void Update () {
		elapsed += Time.deltaTime;
		if (elapsed >= 5f)
		{
        	elapsed = elapsed % 5f;
			GameObject.Instantiate(soldier);
		}
	}
}
