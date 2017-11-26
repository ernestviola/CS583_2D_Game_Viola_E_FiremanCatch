using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScriptGameController : MonoBehaviour {
	public Camera cam;
	public GameObject civilian;

	public Rigidbody2D rb2D;
	public float timeLeft;
	public Text timerText;
	public GameObject gameOverText;
	public GameObject restartButton;
	public GameObject splashScreen;
	public GameObject startButton;
	public firemanController firemanController;

	private float maxWidth;
	private bool playing;

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		playing = false;
		rb2D = GetComponent<Rigidbody2D>();
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float civilianWidth = civilian.GetComponent<Renderer>().bounds.extents.x;
		maxWidth = targetWidth.x - civilianWidth;
	}

	public void StartGame () {
		firemanController.ToggleControl (true);
		splashScreen.SetActive (false);
		startButton.SetActive (false);
		StartCoroutine (Spawn ());
	}

	void FixedUpdate () {
		if (playing) {
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0)
				timeLeft = 0;
			UpdateText ();
		}
	}

	IEnumerator Spawn () {
		yield return new WaitForSeconds (2.0f);
		playing = true;
		while (timeLeft > 0) {
			Vector3 spawnPosition = new Vector3 (
                Random.Range (-maxWidth, maxWidth), 
                transform.position.y, 
                0.0f
            );
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (civilian, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (Random.Range (.5f,.8f));
		}
		yield return new WaitForSeconds (2.0f);
		gameOverText.SetActive (true);
		restartButton.SetActive (true);
	}

	void UpdateText () {
		timerText.text = "Time Left: " + Mathf.RoundToInt(timeLeft);
	}
}
