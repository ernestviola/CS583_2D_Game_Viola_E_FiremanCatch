using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firemanController : MonoBehaviour {

	public Camera cam;
	public Rigidbody2D rb2D;
	public Renderer rend;
	private float maxWidth;

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		rb2D = GetComponent<Rigidbody2D>();
		rend = GetComponent<Renderer>();
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float firemanWidth = rend.bounds.extents.x;
		maxWidth = targetWidth.x - firemanWidth;
	}

	// Update is called once per physics timestep
	void FixedUpdate () {
		Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
		Vector3 targetPosition = new Vector3 (rawPosition.x, 0.0f, 0.0f);
		float targetWidth = Mathf.Clamp (targetPosition.x, -maxWidth, maxWidth);
		targetPosition = new Vector3 (targetWidth, targetPosition.y, targetPosition.z);
		rb2D.position =  targetPosition;
	}
}
