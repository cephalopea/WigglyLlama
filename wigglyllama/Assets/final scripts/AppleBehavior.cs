using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleBehavior : MonoBehaviour {

	//collects collision data from llama head and moves apple
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "CurrentHead") {
			Vector3 localPos = this.transform.localPosition;
			localPos.y = localPos.y + 0.85f;
			this.transform.localPosition = localPos;
		} else {
			//nothing
		}
	}


	//print how many apples have been eaten
	void PrintApples() {
		//use onGUI to display numberOfApplesEaten
	}
		
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
