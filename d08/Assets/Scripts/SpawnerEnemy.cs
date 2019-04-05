using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour {

	public GameObject	female;
	public GameObject	male;
	public int 			maxEnemies = 5;
	public List<GameObject> enemies = new List<GameObject>();

	private float		SpawnTimer = 10f;
	// Use this for initialization
	void Start () {
		while (enemies.Count < maxEnemies/2) {
			SpawnTimer = 0f;	
			GameObject enemy;
			if (Random.Range(0, 2) == 1)
				enemy = Instantiate(female, new Vector3(transform.position.x + Random.Range(-5, 5), transform.position.y + Random.Range(-5, 5), transform.position.z + Random.Range(-5, 5)), Quaternion.identity);
			else
				enemy = Instantiate(male, new Vector3(transform.position.x + Random.Range(-5, 5), transform.position.y + Random.Range(-5, 5), transform.position.z + Random.Range(-5, 5)), Quaternion.identity);
			enemy.transform.parent = gameObject.transform;
			enemies.Add(enemy);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (enemies.Count < maxEnemies)
		{
			SpawnTimer += Time.deltaTime;
			if (SpawnTimer >= 10f) {
				SpawnTimer = 0f;	
				GameObject enemy;
				if (Random.Range(0, 2) == 1)
					enemy = Instantiate(female, new Vector3(transform.position.x + Random.Range(-5, 5), transform.position.y + Random.Range(-5, 5), transform.position.z + Random.Range(-5, 5)), Quaternion.identity);
				else
					enemy = Instantiate(male, new Vector3(transform.position.x + Random.Range(-5, 5), transform.position.y + Random.Range(-5, 5), transform.position.z + Random.Range(-5, 5)), Quaternion.identity);
				enemy.transform.parent = gameObject.transform;
				enemies.Add(enemy);
			}
		}
	}
}
