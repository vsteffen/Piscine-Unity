using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orcs_Spawner : MonoBehaviour {
	public static Orcs_Spawner	instance { get; private set;}
	public Orcs			orc;
	private float 		elapsed;
	private bool 		firstTime;
	public float		spawn_time;

	void Awake() {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		elapsed = 0f;
		firstTime = true;
	}

	// Update is called once per frame
	void Update () {
		if (firstTime)
		{
			GameObject.Instantiate(orc);
			firstTime = false;
		}
		elapsed += Time.deltaTime;
		if (elapsed >= spawn_time)
		{
        	elapsed = elapsed % spawn_time;
			GameObject.Instantiate(orc);
		}
	}

	public void IncreaseSpawnTime(float increase) {
		spawn_time -= increase;
	}
}
