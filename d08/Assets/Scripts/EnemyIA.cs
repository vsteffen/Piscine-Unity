using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour {

	public Animator			anim;
	public GameObject		target;
	public NavMeshAgent	nav;
	private float			timer = 0;
	// Use this for initialization
	void Start () {
		target = null;
		nav = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Stats>().hp <= 0)
		{
			if (timer == 0f) {
				transform.parent.GetComponent<SpawnerEnemy>().enemies.Remove(gameObject);
				// GameManager.gm.maya.RemoveTargetIfDead(gameObject);
				nav.isStopped = true;
				anim.SetBool("dead", true);
			}	
			timer += Time.deltaTime;
			if (timer >= 2.833f)
			{			
				StartCoroutine(Death());
				return;
			}
		}
		if (target) {
			if (Vector3.Distance(target.transform.position, transform.position) < 2f) {
				nav.destination = transform.position;
				anim.SetBool("attack", true);
				transform.LookAt(target.transform.position);
				if (GetComponent<Stats>().hp > 0)
					GameManager.gm.maya.TryToSetTarget(gameObject);
			}
			else {
				anim.SetBool("attack", false);
				nav.destination = target.transform.position;
			}
		}
	}

	IEnumerator Death() {
        yield return new WaitForSeconds(2);
		GetComponent<CharacterController>().enabled = false;
		GetComponent<NavMeshAgent>().enabled = false;
		for (float i = 0; i < 2f; i += 0.1f)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
	        yield return new WaitForSeconds(0.1f);
		}
		Destroy(gameObject);
    }
}
