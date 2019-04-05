using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager	gm;
	public PlayerBehavior		maya;
	public Vector3				offset;
	private Camera 				cam;

	void Awake() {
		gm = this;
	}

	// Use this for initialization
	void Start () {
        cam = Camera.main;	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = maya.transform.position + offset;
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100))
		{
			// Debug.Log(hit.collider);
			Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
			if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.CompareTag("Zombie") && hit.collider.gameObject.GetComponent<Stats>().hp > 0) {
				maya.SetTarget(hit.collider.gameObject);
			}
			else if (Input.GetMouseButton(1)) {
				maya.SetDestination(transform.position + hit.distance * ray.direction);
			}

		}
	}
}
