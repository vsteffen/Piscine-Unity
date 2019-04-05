using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerBehavior : MonoBehaviour {
	public float			time_anim = 0.867f;

	private GameObject		target;
	private float			timerDegat;
	private Animator		anim;
	private NavMeshAgent	nav;

	void Start()
    {
		nav = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update () {
		if (target && target.GetComponent<Stats>().hp <= 0)
		{
			gameObject.GetComponent<Stats>().xp += target.gameObject.GetComponent<Stats>().xp;
			gameObject.GetComponent<Stats>().money += target.gameObject.GetComponent<Stats>().money;
			target = null;
		}
		if (target && Vector3.Distance(target.transform.position, transform.position) > 2f && !anim.GetBool("attack"))
			nav.destination = target.transform.position;
		if (Vector3.Distance(nav.destination, transform.position) < 1f) {
			anim.SetBool("run", false);
		}
		if (target && Vector3.Distance(target.transform.position, transform.position) < 2f) {
			timerDegat += Time.deltaTime;
			anim.SetBool("attack", true);
			transform.LookAt(target.transform.position);
			if (timerDegat >= time_anim) {
				timerDegat = 0f;
				float degat = GetComponent<Stats>().GetRealDamage(target.GetComponent<Stats>());
				Debug.Log("Maya inflicted " + degat + " to " + target.name);
				target.GetComponent<Stats>().hp -= degat;
			}
		}
		else {
			timerDegat = 0f;
			anim.SetBool("attack", false);
		}
	}

	public void SetTarget(GameObject new_target) {
		target = new_target;
		timerDegat = 0f;
	}

	public GameObject GetTarget() {
		return (target);
	}

	public void SetDestination(Vector3 new_dest) {
		target = null;
		anim.SetBool("run", true);
		if (!anim.GetBool("attack"))
			nav.destination = new_dest;
	}

	public void TryToSetTarget(GameObject enemy) {
		if (!target && Vector3.Distance(nav.destination, enemy.transform.position) < 2f)
			SetTarget(enemy);
	}
}
