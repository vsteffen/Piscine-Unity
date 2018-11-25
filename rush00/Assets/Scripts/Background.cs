using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour {
	public List<Color> colors;
	private Color actual;
	private Color next;
	private float t;
	private Image img;
	private bool switching;

	// Use this for initialization
	void Start () {
		t = 0;
		actual = colors[0];
		next = colors[1];
		switching = false;
		Invoke("Switch", 0.5f);
		img = gameObject.GetComponent<Image>();
	}
	
	void Switch()
	{
		actual = next;
		next = colors[Random.Range(0, colors.Count)];
		switching = !switching;
	}

	// Update is called once per frame
	void Update () {
		if (switching)
		{
			img.color = Color.Lerp(actual, next, t);
			t += (Time.deltaTime * 3);
			if (t >= 1)
			{
				switching = false;
				t = 0;
				Invoke("Switch", 0.5f);
			}
		}
	}
}
