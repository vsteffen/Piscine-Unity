using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour , IPointerEnterHandler, ISelectHandler, IDeselectHandler {

	private bool selected;
	private int way;
	public bool pointer;
	public bool isStart;
	// Use this for initialization
	void Start () {
		selected = false;
		if (isStart)
		{
			gameObject.GetComponent<Button>().Select();
		}
		way = 7;
		pointer = false;
	}
	
	public void OnPointerEnter(PointerEventData eventData)
	{
		gameObject.GetComponent<Button>().Select();
	}
	
	public void OnSelect(BaseEventData eventData)
	{
		selected = true;
	}

	public void OnDeselect(BaseEventData eventData)
	{
		selected = false;
	}

	public void Exit()
	{
		Application.Quit();
	}

	public void StartGame()
	{
		SceneManager.LoadScene("Scenes/level0");
	}

	// Update is called once per frame
	void Update () {
		if (selected || pointer)
		{
			if (transform.rotation.z > Mathf.Deg2Rad * 3 || transform.rotation.z < Mathf.Deg2Rad * -3)
				way = -way;
			if (Time.timeScale == 0)
				transform.Rotate(new Vector3 (0, 0, way * Time.unscaledDeltaTime));
			else
			{
				transform.Rotate(new Vector3 (0, 0, way * Time.deltaTime));
			}
		}
		else
			transform.rotation = Quaternion.identity;
	}
}
