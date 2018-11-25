using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishFlash : MonoBehaviour {
	public SpriteRenderer 	sprite;
	public bool				fadeAway;

    public void Start()
    {
		sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeImage());
    }
 
    IEnumerator FadeImage()
    {
		while (true == true)
		{
			if (fadeAway)
			{

				fadeAway = false;
				for (float i = 0.6f; i >= 0.2f; i -= Time.deltaTime * 0.8f)
				{
					sprite.color = new Color(1, 1, 1, i);
					yield return new WaitForSeconds(0.05f);
				}
			}
			else
			{
				fadeAway = true;
				for (float i = 0.2f; i <= 0.6f; i += Time.deltaTime * 0.8f)
				{
					sprite.color = new Color(1, 1, 1, i);
					yield return new WaitForSeconds(0.05f);
				}
			}
		}
    }

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "player")
			GameManager.gm.FinishMenu();
	}
}
