using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class SliderControl : MonoBehaviour
{
    public Slider slider;
	public static SliderControl sld;
    public int                  playerVisible;

	void Awake () {
		if (sld == null)
        {
			sld = this;
            playerVisible = 0;
        }
    }

    public void Update() {
        if (playerVisible > 0 && slider.value < 1f)
            slider.value += Time.deltaTime * 0.4f;
        else if (playerVisible == 0 && slider.value > 0f)
            slider.value -= Time.deltaTime * 0.1f;
    }
}