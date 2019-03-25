using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {
	public GameObject			A_prefab;
	public GameObject			S_prefab;
	public GameObject			D_prefab;
	private float 				elapsed;
	private GameObject			A_key;
	private GameObject			S_key;
	private GameObject			D_key;

	// Use this for initialization
	void Start () {
		elapsed = 0f;
		A_key = null;
		S_key = null;
		D_key = null;
	}
	
	// Update is called once per frame
	void Update () {
		elapsed += Time.deltaTime;
		if (elapsed >= 0.5f)
		{
        	elapsed = elapsed % 0.5f;
			int cube_type = Random.Range(0, 3);
			if (cube_type == 0)
			{
				if (!A_key)
					A_key = GameObject.Instantiate(A_prefab);
			}
			else if (cube_type == 1)
			{
				if (!S_key)
					S_key = GameObject.Instantiate(S_prefab);
			}
			else if (cube_type == 2)
			{
				if (!D_key)
					D_key = GameObject.Instantiate(D_prefab);
			}
		}
	}
}
