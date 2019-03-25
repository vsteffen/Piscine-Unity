using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {
	private	Vector3		initialPos;
	public float 		speed;
	public GameObject	bird;
	private ulong		score;
	private float		birdPipeMaxY;
	private float		birdPipeMinY;
	private float		birdMaxY;
	private float		birdMinY;
	private float		dangerPipeStart;
	private float		dangerPipeEnd;
	private bool		passingPipe;
	private bool		gameOver;

	// Use this for initialization
	void Start () {
		birdPipeMaxY = 1.96f;
		birdPipeMinY = -1.04f;
		birdMaxY = -1.04f;
		birdMinY = -2.66f;
		dangerPipeStart = -0.37f;
		dangerPipeEnd = -2.7f;
		initialPos = transform.position;
		score = 0;
		passingPipe = false;
		gameOver = false;
	}

	bool IsBetweenPipe()
	{
		return (transform.position.x <= dangerPipeStart && transform.position.x >= dangerPipeEnd);
	}

	void detectPipePassed(float birdX)
	{
		if (passingPipe && !IsBetweenPipe())
		{
			passingPipe = false;
			score += 5;
			speed += 0.5f;
		}
		if (!passingPipe && IsBetweenPipe())
			passingPipe = true;
	}

	void GameOver() {
		gameOver = true;
		Debug.Log("Score: " + score);
		Debug.Log("Time: " + Mathf.RoundToInt(Time.time) + "s");
		bird.transform.Translate(-10f, -10f, -10f);
	}

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * Time.deltaTime * speed);
		if (!gameOver) {
			float birdX = bird.transform.position.x;
			float birdY = bird.transform.position.y;
			if ((IsBetweenPipe() && (birdY > birdPipeMaxY || birdY < birdPipeMinY)) || birdMinY >= birdY)
				GameOver();
			detectPipePassed(birdX);
			if (transform.position.x < -3.5f)
				transform.position = initialPos;
		}
	}
}
