using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour {
	private EnemyIA	zombie;

	void OnTriggerEnter(Collider col) {
		zombie = transform.parent.gameObject.GetComponent<EnemyIA>();
		if (zombie.GetComponent<Stats>().hp > 0 && !zombie.target && col.gameObject.CompareTag("Player")) {
			zombie.target = col.gameObject;
			zombie.anim.SetBool("run", true);
		}
	}

	void OnTriggerExit(Collider col) {
		if (zombie.GetComponent<Stats>().hp > 0 && zombie.target == col.gameObject) {
			zombie.target = null;
			zombie.anim.SetBool("run", false);
			zombie.nav.destination = zombie.transform.position;
		}
	}
}
