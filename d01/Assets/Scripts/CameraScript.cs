using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CameraScript : MonoBehaviour {
	public GameObject	player;
	public GameObject	thomas;
	public GameObject	john;
	public GameObject	claire;
	private float		offset_x;
	private float		offset_y;
	private Vector3		initial_pos;

	void Start () {
		initial_pos = transform.position;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
		{
			player = thomas;
		}
		else if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
		{
			player = john;
		}
		else if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
		{
			player = claire;
		}
		offset_x = player.transform.position.x;
		offset_y = player.transform.position.y;
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	void LateUpdate () {
		transform.position = new Vector3(offset_x, offset_y, transform.position.z);
	}
}
