using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_Neck_Control : MonoBehaviour {
	
	//stores whether an apple has been hit by any head
	bool appleHit;

	//destroys old head, loads new neck, positions new neck
	void NewNeck() {
		GameObject oldHead = GameObject.FindWithTag ("CurrentHead");
		Destroy (oldHead);
		GameObject newNeck = Instantiate (Resources.Load ("neck head")) as GameObject;
		Transform oldNeck = GameObject.FindWithTag ("Current Neck").transform;
		newNeck.transform.position = oldNeck.position;
	}

	//connects new neck to llama with hinge joints
	void ConnectNeck() {
		HingeJoint2D thisAnchor = GameObject.FindWithTag ("New Neck").gameObject.AddComponent<HingeJoint2D> ();
		thisAnchor.connectedBody = GameObject.FindWithTag ("Current Neck").GetComponent<Rigidbody2D> ();
		Vector2 neckAnchor = new Vector2 (0f, -0.27f);
		thisAnchor.anchor = neckAnchor;
		thisAnchor.autoConfigureConnectedAnchor = false;
		Vector2 neckConnect = new Vector2 (0.004f, 0.27f);
		thisAnchor.connectedAnchor = neckConnect;
	}

	//changes last neck's tag to "obsolete", changes newest neck's tag to "Current Neck"
	void MoveTag () {
		GameObject oldNeck = GameObject.FindWithTag ("Current Neck");
		oldNeck.gameObject.tag = "obsolete";
		GameObject newNeck = GameObject.FindWithTag ("New Neck");
		newNeck.gameObject.tag = "Current Neck";
	}

	//adds new head
	void NewHead() {
		GameObject newHead = Instantiate (Resources.Load ("Llama Head")) as GameObject;
	}

	//checks to see if any head has hit an apple
	void CheckHeadAppleBool() {
		GameObject llamaHead = GameObject.FindWithTag ("CurrentHead");
		if (llamaHead.GetComponent<Llama_Head_Code> () == null) {
			appleHit = llamaHead.GetComponent<First_Head_Code> ().hitApple;
		} else {
			appleHit = llamaHead.GetComponent<Llama_Head_Code> ().hitApple;
		}
	}

	//adds a new neck and head if any head has hit an apple
	void AddLlamaLayer() {
		if (appleHit == true) {
			NewNeck ();
			ConnectNeck ();
			MoveTag ();
			NewHead ();
			GameObject neckNum = GameObject.FindWithTag ("ground");
			neckNum.GetComponent<Input_World_Reference> ().numOfNeck = neckNum.GetComponent<Input_World_Reference> ().numOfNeck + 1;
		} else {
			//nothing
		}
	}

	//adds a new neck and head if the user presses the "w" key (used for testing)
	void ManualAddLlamaLayer() {
		if (Input.GetKeyDown ("1")) {
			NewNeck ();
			ConnectNeck ();
			MoveTag ();
			NewHead ();
			GameObject neckNum = GameObject.FindWithTag ("ground");
			neckNum.GetComponent<Input_World_Reference> ().numOfNeck = neckNum.GetComponent<Input_World_Reference> ().numOfNeck + 1;
		}
	}

	//plaes and configures neck's hinge joints
	void HingeJointSetupN() {
		HingeJoint2D thisAnchor = GameObject.Find ("llamaHead").gameObject.AddComponent<HingeJoint2D> ();
		thisAnchor.connectedBody = GameObject.Find ("neck base").GetComponent<Rigidbody2D> ();
		Vector2 neckAnchor = new Vector2 (0f, -0.27f);
		thisAnchor.anchor = neckAnchor;
		Vector2 neckConnect = new Vector2 (0.004f, -0.27f);
		thisAnchor.connectedAnchor = neckConnect;
	}

	// Use this for initialization
	void Start () {
		HingeJointSetupN ();
	}
	
	// Update is called once per frame
	void Update () {
		ManualAddLlamaLayer ();
		CheckHeadAppleBool ();
		AddLlamaLayer ();
	}
}
