using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager			gm;
	public Player						player;
	public int							playerRoom;
	public GameObject					canvasPause;
	public GameObject					finishMenu;
	public GameObject					deathMenu;
	[HideInInspector]public Enemy[]		enemies;
	public List<FireWeapons>			weaponsArray;
	private bool						pause;
	public List<Enemy>					triggeredEnemies;
	public List<Checkpoint>				checkpoints;
	public PathFinding					pathfinder;
	public AudioSource					win_sound;
	public AudioSource					loose_sound;

	// Use this for initialization
	void Awake () {
		gm = this;
		pause = false;
		GameObject[] cpGO = GameObject.FindGameObjectsWithTag("checkpoint");
		foreach (GameObject go in cpGO)
		{
			checkpoints.Add(go.GetComponent<Checkpoint>());
		}
	}

	public void Pause()
	{
		Time.timeScale = 0f;
		pause = true;
		canvasPause.SetActive(true);
	}
	
	public void UnPause()
	{
		Time.timeScale = 1f;
		pause = false;
		canvasPause.SetActive(false);
	}

	public void BackMainMenu()
    {
        UnPause();
        SceneManager.LoadScene("Scenes/Menu");
    }

	public void FinishMenu()
	{
		win_sound.Play(0);
		Time.timeScale = 0f;
		pause = true;
		finishMenu.SetActive(true);
	}

	public void DeathMenu()
	{
		loose_sound.Play(0);
		Time.timeScale = 0f;
		pause = true;
		deathMenu.SetActive(true);
	}

	public void LoadLevel(string level)
    {
        UnPause();
        SceneManager.LoadScene("Scenes/level" + level);
    }

	public FireWeapons GetRandomWeapon() {
		return (Instantiate(weaponsArray[Random.Range(0, weaponsArray.Count)]));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!pause)
			{
				Pause();
			}
			else
			{
				UnPause();
			}
		}
	}

	void FixUpdate() {
	}
}
