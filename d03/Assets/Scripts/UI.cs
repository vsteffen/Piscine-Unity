using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {
	public Texture2D cursorTexture;

	// Use this for initialization
	void Start () {
		Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Restart()
	{
		SceneManager.LoadScene("Scenes/ex00");
	}
	public void doExitGame() {
    	Application.Quit();
 	}
	
	public void StartGame() {
		SceneManager.LoadScene("Scenes/ex01");
	}
}
