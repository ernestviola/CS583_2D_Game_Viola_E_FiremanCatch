using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {

	public Text scoreText;
	public int civilianValue;

	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
		UpdateScore ();
	}

	void OnTriggerEnter2D () {
		score += civilianValue;
		UpdateScore ();
	}

	void UpdateScore () {
		scoreText.text = "Score: " + score;
	}
}
