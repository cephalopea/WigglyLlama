using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Input_World_Reference : MonoBehaviour {
	
	//stores how many necks are present in the game
	public int numOfNeck = 0;
	//stores whether head has hit ground
	public bool hitHead;

	void OnGUI() {
		string garry = GameObject.FindWithTag ("Current Neck").GetComponent<ControlNeck> ().garry;
		GUI.Label(new Rect(10, 10, 150, 20), "Hit Space to restart!");
		GUI.Label(new Rect(10, 50, 50, 20), garry);
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "CurrentHead") {
			hitHead = true;
		} else {
			//nothing
		}
	}

	void RestartCurrentScene(){
		Scene scene = SceneManager.GetActiveScene(); 
		SceneManager.LoadScene(scene.name);
	}

	void LoadTitleScreen() {
		SceneManager.LoadScene ("title screen");
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			RestartCurrentScene ();
		} if (Input.GetKeyDown (KeyCode.Escape)) {
			LoadTitleScreen ();
		}
	}
}
