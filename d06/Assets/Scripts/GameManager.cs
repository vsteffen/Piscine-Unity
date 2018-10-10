using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager	gm;
	public ParticleSystem		fanParticle;
	public TextUI				textUI;
	public bool					passKey;
	public GameObject			camPlayer;
	public Camera				camWinLoose;
	private bool				gameover;

	void Start() {
		gm = this;
		fanParticle.GetComponent<ParticleSystem>().Stop();
		passKey = false;
		camWinLoose.enabled = false;
		gameover = false;
	}

	public void Gameover(string msg) {
		camPlayer.SetActive(false);
        camWinLoose.enabled = !camWinLoose.enabled;
		SliderControl.sld.gameObject.SetActive(false);
		GameManager.gm.DisplayMsg(msg);
		StartCoroutine(waitWinLooseScreen());
	}
 
     IEnumerator waitWinLooseScreen() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Scenes/d06");
     }

	private void Update() {
		if (SliderControl.sld.slider.value >= 1f && !gameover)
		{
			gameover = true;
			Gameover("You loose ! You have been spotted !");
		}
	}

	public void DisplayMsg(string msg) {
		textUI.i.text = msg;
		textUI.StartCoroutine(textUI.FadeText(true));
	}

	public void RemoveMsg(string msg) {
		textUI.StartCoroutine(textUI.FadeText(false));
	}	
}
