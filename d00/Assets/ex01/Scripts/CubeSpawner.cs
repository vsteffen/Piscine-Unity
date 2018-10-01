using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {
	public GameObject	A_prefab;
	public GameObject	S_prefab;
	public GameObject	D_prefab;
	private float 		elapsed;

	// Use this for initialization
	void Start () {
		elapsed = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		elapsed += Time.deltaTime;
		if (elapsed >= 1.8f)
		{
        	elapsed = elapsed % 1.8f;
			int cube_type = Random.Range(0, 3);
			if (cube_type == 0)
			{
				GameObject.Instantiate(A_prefab);
			}
			else if (cube_type == 1)
			{
				GameObject.Instantiate(S_prefab);
			}
			else if (cube_type == 2)
			{
				GameObject.Instantiate(D_prefab);
			}
		}
	}
}
