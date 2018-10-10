using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour {
		[HideInInspector] public	Text	i;
		public int							fadeActive;
		public bool							fadeWay;
		private float						t;

        public void Start()
        {
			i = GetComponent<Text>();
			t = 1f;
			fadeActive = 0;
			i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        }

		public IEnumerator FadeText(bool way)
		{
			if (way)
			{
				fadeActive++;
				fadeWay = true;
				// i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
				while (i.color.a < 1.0f && fadeWay)
				{
					i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
					yield return null;
				}
			}
			else
			{
				fadeActive--;
				if (fadeActive < 1)
				{
					fadeWay = false;
					// i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
					Debug.Log(i.color.a);
					while (i.color.a > 0.0f && !fadeWay)
					{
						i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
						yield return null;
					}
				}
			}
		}
}
