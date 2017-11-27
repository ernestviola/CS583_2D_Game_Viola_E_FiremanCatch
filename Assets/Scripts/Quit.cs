using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {
	public void doQuit() {
		Debug.Log ("has quit");
		Application.Quit();
	}
}
