using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour {
	public GameObject		thing;
	public int				id;
	public string			msg;

	private void OnTriggerEnter(Collider other) {
		Debug.Log("COLLIDE");
		GameManager.gm.DisplayMsg(msg);
	}

	private void OnTriggerStay(Collider other) {
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (id == 0)
			{
				thing.GetComponent<ParticleSystem>().Play();
				GameManager.gm.RemoveMsg(msg);
			}
			else if (id == 1)
			{
				thing.SetActive(false);
			}
			else if (id == 2)
			{

			}
		}
	}

	private void OnTriggerExit(Collider other) {
		GameManager.gm.RemoveMsg(msg);
	}

}
