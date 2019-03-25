﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour {
	public GameObject		thing;
	public GameObject		thing2;
	public GameObject		thing3;
	public int				id;
	public string			msg;
	public string			msg2;
	private bool			used;

	private void OnTriggerEnter(Collider other) {
		if (id == 0 || id == 1)
		{
			if (!used)
				GameManager.gm.DisplayMsg(msg);
		}
		else if (id == 2)
		{
			if (!used)
			{
				if (GameManager.gm.passKey)
					GameManager.gm.DisplayMsg(msg);
				else
					GameManager.gm.DisplayMsg(msg2);
			}
		}
		else
			GameManager.gm.DisplayMsg(msg);
	}

	private void OnTriggerStay(Collider other) {
		if (Input.GetKeyDown(KeyCode.E) && !used)
		{
			if (id == 0)
			{
				thing.GetComponent<ParticleSystem>().Play();
				thing2.GetComponent<Light>().range = 2f;
				thing2.GetComponent<Light>().intensity = 3f;
				thing3.SetActive(false);
				GameManager.gm.RemoveMsg(msg);
				used = true;
			}
			else if (id == 1)
			{
				thing.SetActive(false);
				GameManager.gm.RemoveMsg(msg);
				GameManager.gm.passKey = true;
			}
			else if (id == 2 && GameManager.gm.passKey)
			{
				used = true;
				GameManager.gm.RemoveMsg(msg);
			}
			else if (id == 3)
				GameManager.gm.Gameover("You win ! Congratulations !");
		}
	}

	private void OnTriggerExit(Collider other) {
		if (!used)
		{
			GameManager.gm.RemoveMsg(msg);
		}
	}

}