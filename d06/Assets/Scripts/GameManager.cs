using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager gm;

	private void Update() {
		if (SliderControl.sld.slider.value >= 1f)
			Debug.Log("GAMEOVER");
	}
}
