using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGameController : MonoBehaviour {
	public Camera cam;
	public GameObject civilian;

	public Rigidbody2D rb2D;
	public float timeLeft;
	private float maxWidth;

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		rb2D = GetComponent<Rigidbody2D>();
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float civilianWidth = civilian.GetComponent<Renderer>().bounds.extents.x;
		maxWidth = targetWidth.x - civilianWidth;
		StartCoroutine (Spawn ());
	}

	void FixedUpdate () {
		timeLeft -= Time.deltaTime;
	}

	IEnumerator Spawn () {
		yield return new WaitForSeconds (2.0f);
		while (timeLeft > 0) {
			Vector3 spawnPosition = new Vector3 (
                Random.Range (-maxWidth, maxWidth), 
                transform.position.y, 
                0.0f
            );
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (civilian, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (Random.Range (1.0f,2.0f));
		}
	}
}
