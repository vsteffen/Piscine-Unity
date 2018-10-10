using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager	gm;
	public ParticleSystem		fanParticle;
	public TextUI				textUI;

	void Start() {
		gm = this;
		fanParticle.GetComponent<ParticleSystem>().Stop();
	}

	public void Gameover() {
		Debug.Log("GAMEOVER");
	}

	private void Update() {
		if (SliderControl.sld.slider.value >= 1f)
			Gameover();
	}

	public void DisplayMsg(string msg) {
		textUI.i.text = msg;
		textUI.StartCoroutine(textUI.FadeText(1f));
	}

	public void RemoveMsg(string msg) {
		textUI.i.text = msg;
		textUI.StartCoroutine(textUI.FadeText(1f));
	}

	
}
