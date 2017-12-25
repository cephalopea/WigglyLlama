using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_Neck_Control : MonoBehaviour {

	//despawns old head, spawns new head/neck prefab
	void NewNeck() {
		GameObject oldHead = GameObject.FindWithTag ("CurrentHead");
		Destroy (oldHead);
		GameObject newHead = Instantiate (Resources.Load ("neck head")) as GameObject;
	}

	//creates and configures new neck joint
	void ConnectNeck() {
		HingeJoint2D thisAnchor = GameObject.FindWithTag ("New Neck").gameObject.AddComponent<HingeJoint2D> ();
		thisAnchor.connectedBody = GameObject.FindWithTag ("Current Neck").GetComponent<Rigidbody2D> ();
		Vector2 neckAnchor = new Vector2 (0f, -0.27f);
		thisAnchor.anchor = neckAnchor;
		thisAnchor.autoConfigureConnectedAnchor = false;
		Vector2 neckConnect = new Vector2 (0.004f, 0.27f);
		thisAnchor.connectedAnchor = neckConnect;
	}

	//creates and configures new head joint
	void ConnectHead() {	
		HingeJoint2D thisAnchor = GameObject.Find ("llamaHead").gameObject.AddComponent<HingeJoint2D> ();
		thisAnchor.connectedBody = GameObject.Find ("neck base").GetComponent<Rigidbody2D> ();
		Vector2 neckAnchor = new Vector2 (0f, -0.27f);
		thisAnchor.anchor = neckAnchor;
		Vector2 neckConnect = new Vector2 (0.004f, -0.27f);
		thisAnchor.connectedAnchor = neckConnect;
	}

	//removes "Current Neck" tag from last neck and tags it "obsolete", retags new neck as "Current Neck"
	void MoveTag () {
		GameObject oldNeck = GameObject.FindWithTag ("Current Neck");
		oldNeck.gameObject.tag = "obsolete";
		GameObject newNeck = GameObject.FindWithTag ("New Neck");
		newNeck.gameObject.tag = "Current Neck";
	}

	//adds one to Input_World_Reference.numOfNeck
	void IncreaseNeckNum() {
		GameObject neckNumObj = GameObject.FindWithTag ("ground");
		int neckNum = neckNumObj.GetComponent<Input_World_Reference> ().numOfNeck;
		Debug.Log (neckNum);
	}
		
	// Use this for initialization
	void Start () {
		ConnectHead();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("d")) {
			NewNeck ();
		} if (Input.GetKeyDown ("d")) {
			ConnectNeck ();
		} if (Input.GetKeyDown ("d")) {
			MoveTag ();
		} if (Input.GetKeyDown ("d")) {
			IncreaseNeckNum ();
		}
	}
}
