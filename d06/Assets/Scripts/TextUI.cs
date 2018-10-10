using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour {
		 [HideInInspector] public	Text	i;
		 public bool						fadeWay;
		 public	int							fadeActive;
     
         public void Start()
         {
			 i = GetComponent<Text>();
			 fadeWay = false;
			 fadeActive = 0;
         }

		public IEnumerator FadeText(float t)
		{
			if (fadeActive > 1 && !fadeWay)
			{
				fadeWay = !fadeWay;
				if (fadeWay)
				{
					fadeActive++;
					i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
					while (i.color.a < 1.0f && fadeWay)
					{
						i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
						yield return null;
					}
				}
				else
				{
					fadeActive--;
					i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
					while (i.color.a > 0.0f && !fadeWay)
					{
						i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
						yield return null;
					}
				}
			}
			else
				fadeActive--;
		}
}
