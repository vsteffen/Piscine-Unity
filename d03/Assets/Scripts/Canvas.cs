using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Canvas : MonoBehaviour {

	// Use this for initialization
	public GameObject vraiment;
	public GameObject menu;
	public GameObject text;
	public GameObject endGame;
	public GameObject rang;
	public GameObject score;
	public GameObject gameOver;
	public GameObject nextLevel;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && menu.gameObject.activeSelf == false  && vraiment.gameObject.activeSelf == false && endGame.gameObject.activeSelf == false)
		{
			gameManager.gm.pause(true);
			menu.gameObject.SetActive(true);
		}
		if (gameManager.gm.statusGame == 0)
		{
			displayScore();
			// score.GetComponent<Text>().text = "" + gameManager.gm.score;
			endGame.gameObject.SetActive(true);
			gameOver.SetActive(true);
			// nextLevel.SetActive(false);
			text.GetComponent<Text>().text = "GameOver";
		}
		else if (gameManager.gm.statusGame == 2)
		{
			displayScore();
			endGame.gameObject.SetActive(true);
			nextLevel.SetActive(true);
			text.GetComponent<Text>().text = "Victory";
			// gameOver.SetActive(false);
		}
		else
			endGame.gameObject.SetActive(false);
	}

	private void displayScore() {
		float grade;
		string str;

		score.GetComponent<Text>().text = "Score : " + gameManager.gm.score;

		grade = ((float)gameManager.gm.playerEnergy / (float)gameManager.gm.playerStartEnergy + (float)gameManager.gm.playerHp / (float)gameManager.gm.playerMaxHp) / 2f;
		if (grade < 0.15f)
			str = "F";
		else if (grade < 0.3f)
			str = "E";
		else if (grade < 0.45f)
			str = "D";
		else if (grade < 0.6f)
			str = "C";
		else if (grade < 0.75f)
			str = "B";
		else if (grade < 0.9f)
			str = "A";
		else if (grade < 1.05f)
			str = "S";
		else if (grade < 1.2f)
			str = "SS";
		else
			str = "SSS";
		rang.GetComponent<Text>().text = "Rank : " + str;
	}

	public void loadNextLevel(int data) {
		endGame.gameObject.SetActive(false);
		nextLevel.SetActive(false);
		SceneManager.LoadScene("Scenes/ex0" + data);
	}

	public void restartGame() {
		endGame.gameObject.SetActive(false);
		nextLevel.SetActive(false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
