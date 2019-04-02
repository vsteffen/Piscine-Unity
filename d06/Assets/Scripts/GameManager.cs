using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager	gm;
	public Light				alerte_light;
	public ParticleSystem		fanParticle;
	public TextUI				textUI;
	public bool					passKey;
	public GameObject			camPlayer;
	public Camera				camWinLoose;
	private bool				gameover;

	public AudioSource[] 			audio;
	public AudioClip				run;
	public AudioClip				normal;
	public AudioClip				alarm;
	public AudioClip				end;
	public AudioClip				pick;
	public AudioClip				door;
	private bool[]					music_playing = new bool[5];

	void Start() {
		gm = this;
		fanParticle.GetComponent<ParticleSystem>().Stop();
		audio = GetComponents<AudioSource>();
		passKey = false;
		camWinLoose.enabled = false;
		gameover = false;
		Cursor.visible = false;
		StartCoroutine(InitBeginMsg());
	}

	public void Gameover(string msg) {
		camPlayer.SetActive(false);
        camWinLoose.enabled = !camWinLoose.enabled;
		SliderControl.sld.gameObject.SetActive(false);
		GameManager.gm.DisplayMsg(msg);
		alerte_light.GetComponent<Light>().enabled = true;
		alerte_light.GetComponent<Light>().intensity = 5f;
		SetMusic(2, true);	
		StartCoroutine(waitWinLooseScreen());
	}

	IEnumerator InitBeginMsg() {
		DisplayMsg("Find a way to exit this building ! Try to find all documents !");
        yield return new WaitForSeconds(3);
		RemoveMsg("Find a way to exit this building ! Try to find all documents !");
     }


     IEnumerator waitWinLooseScreen() {
        yield return new WaitForSeconds(5);
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

	public void SetMusic(int choice, bool choice2) {
		if (choice == 1)
			audio[choice].clip = run;
		else if (choice == 0) {
			if (choice2)
				audio[choice].clip = normal;
			else
				audio[choice].clip = alarm;
			if (music_playing[choice] != choice2)
				audio[choice].Stop();
			music_playing[choice] = choice2;
		}
		else if (choice == 2) {
			AudioSource[] audio_cam_end = camWinLoose.gameObject.GetComponents<AudioSource>();
			audio_cam_end[0].Play();
			audio_cam_end[1].Play();
		}
		else if (choice == 3) {
			if (choice2)
				audio[choice].clip = door;
			else
				audio[choice].clip = pick;
		}
		if (!audio[choice].isPlaying && choice < 2)
			audio[choice].Play();
		if (choice >= 2) {
			audio[choice].Stop();
			audio[choice].PlayOneShot(audio[choice].clip);
		}
	}
}
