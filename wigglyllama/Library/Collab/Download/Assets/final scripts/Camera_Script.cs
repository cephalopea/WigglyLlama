using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour {

	//stores whether head has hit apple
	bool appleHit;

	//sets appleHit equal to hitApple in llama head
	void GetAppleHit() {
		GameObject llamaHead = GameObject.FindWithTag ("CurrentHead");
		if (llamaHead.GetComponent<Llama_Head_Code> () == null) {
			appleHit = llamaHead.GetComponent<First_Head_Code> ().hitApple;
		} else {
			appleHit = llamaHead.GetComponent<Llama_Head_Code> ().hitApple;
		}
	}
		
	void MoveCamera() {
		if (appleHit == true) {
			GameObject apple = GameObject.FindWithTag ("apple");
			Vector2 appleSpot = apple.transform.position;
			int neckNum = GameObject.FindWithTag("ground").GetComponent<Input_World_Reference>().numOfNeck;
			//tweak floats in this transform to alter how camera position changes
			this.transform.position = new Vector2 (appleSpot.x, appleSpot.y);
			Camera Cam = this.gameObject.GetComponent<Camera> ();
			Cam.orthographicSize = (6f + ((neckNum + 1 ) * .1f));
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetAppleHit ();
		MoveCamera ();
	}
}
