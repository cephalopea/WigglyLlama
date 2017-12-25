using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llama_Head_Code : MonoBehaviour {

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

	//places and configures head's hinge joint
	void HingeJointSetupH() {
		this.transform.position = GameObject.FindWithTag ("Current Neck").transform.position;
		HingeJoint2D thisAnchor2 = this.gameObject.AddComponent<HingeJoint2D> ();
		thisAnchor2.connectedBody = GameObject.FindWithTag ("Current Neck").GetComponent<Rigidbody2D> ();
		Vector2 neckAnchor = new Vector2 (0f, -0.27f);
		thisAnchor2.anchor = neckAnchor;
		thisAnchor2.autoConfigureConnectedAnchor = false;
		Vector2 neckConnect = new Vector2 (0.004f, 0.27f);
		thisAnchor2.connectedAnchor = neckConnect;
	}

	// Use this for initialization
	void Start () {
		HingeJointSetupH ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
