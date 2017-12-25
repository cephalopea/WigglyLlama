using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Head_Code : MonoBehaviour {

	//stores whether head has hit an apple, accessed by CheckHeadAppleBool() in Body_Neck_Control
	public bool hitApple;

	//checks whether head has hit an apple
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "apple") {
			hitApple = true;
		} else {
			hitApple = false;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
