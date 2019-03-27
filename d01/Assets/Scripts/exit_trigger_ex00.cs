using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class exit_trigger_ex00 : MonoBehaviour {
	public int			id;
	private static int	correct_cube;

	void Start() {
		correct_cube = 0;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (id == collider.gameObject.GetComponent<playerScript_ex00>().id)
		{
			correct_cube++;
			if (correct_cube == 3)
			{
				Scene actualScene = SceneManager.GetActiveScene();
				if (actualScene.name == "ex02")
					SceneManager.LoadScene("Scenes/ex02_01");
				else if (actualScene.name == "ex03")
					SceneManager.LoadScene("Scenes/ex03_01");
				else if (actualScene.name == "ex03_01")
					SceneManager.LoadScene("Scenes/ex03_02");
				else if (actualScene.name == "ex04")
					SceneManager.LoadScene("Scenes/ex04_01");
				else if (actualScene.name == "ex04_01")
					SceneManager.LoadScene("Scenes/ex04_02");
				else if (actualScene.name == "ex04_02")
					SceneManager.LoadScene("Scenes/ex04_03");
				else
					Debug.Log("You won!");
			}
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (id == collider.gameObject.GetComponent<playerScript_ex00>().id)
		{
			correct_cube--;
		}
	}
}
