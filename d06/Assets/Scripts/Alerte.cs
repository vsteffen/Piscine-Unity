using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alerte : MonoBehaviour {
	private Light	alerte_light;

	void Start() {
		alerte_light = gameObject.GetComponent<Light>();
	}

	// Update is called once per frame
	void Update () {
		if (SliderControl.sld.slider.value >= 0.75f && !alerte_light.enabled) {
			alerte_light.enabled = true;
		}
		else if (SliderControl.sld.slider.value < 0.75f && alerte_light.enabled) {
			alerte_light.enabled = false;
		}
	}
}
