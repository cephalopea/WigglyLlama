using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlNeck : MonoBehaviour {
	
	//initial control key, updated by neckLetters and neckNum
	public string garry = "a";
	//hinge joint on this neck
	HingeJoint2D thisAnchor;
	//string of control keys, used to set garry
	string[] neckLetters = new string[26] {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", 
		"n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
	//number of necks, used to change garry
	int neckNum;

	//sets neckNum equal to numOfNeck in Input_World_Reference
	void CheckNeckNum() {
		neckNum = GameObject.FindWithTag ("ground").GetComponent<Input_World_Reference> ().numOfNeck; 
	}

	//turns motor on and off, runs motor
	//destroys neck joints and disables controls when head hits the ground
	void HingeControls() {
		thisAnchor = this.GetComponent<HingeJoint2D> ();
		if (GameObject.FindWithTag("ground").GetComponent<Input_World_Reference>().hitHead == true) {
			if (thisAnchor == null) {
				//nothing
			} else if (thisAnchor.breakForce != 0) {
				thisAnchor.breakForce = 0;
			} else {
				Debug.Log ("Oops! This was never supposed to run!");
			}
		} else {
			JointMotor2D thisMotor = thisAnchor.motor;
			float jointRotation = this.gameObject.transform.rotation.z;
			if (Input.GetKey(garry) == true) {
				thisAnchor.useMotor = true;
			} else {
				thisAnchor.useMotor = false;
			} if (Input.GetKeyDown (garry)) {
				if (jointRotation > 0) {
					thisMotor.motorSpeed = 80f;
				} else {
					thisMotor.motorSpeed = -80f;
				}
				thisAnchor.motor = thisMotor;
			}
		}
	}

	//changes garry based on number of necks present
	void ChangeGarry() {
		if (neckNum <= 26) {
			string neckControlKey = neckLetters [neckNum];
			garry = neckControlKey;
		} else {
			SceneManager.LoadScene ("credits screen");
		}
	}

	// Use this for initialization
	void Start () {
		thisAnchor = this.gameObject.GetComponent<HingeJoint2D> ();
		CheckNeckNum ();
		ChangeGarry ();
		print (garry);
	}
	
	// Update is called once per frame
	void Update () {
		HingeControls ();
	}
}
