using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class GetHit : MonoBehaviour {

	void OnMouseDown()
	{
		print(":O");
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if(hit)
		{
			print(":x");
			if (hit.collider.tag == "turret")
			{
				print("YOYOYO");
			}
		}
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
