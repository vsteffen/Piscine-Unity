using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDoor : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		GameManager.gm.Gameover();
	}
}
