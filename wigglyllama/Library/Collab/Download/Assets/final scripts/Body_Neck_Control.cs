using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_Neck_Control : MonoBehaviour {

	// Use this for initialization
	void Start () {
		HingeJoint2D thisAnchor = GameObject.Find ("llamaHead").gameObject.AddComponent<HingeJoint2D> ();
		thisAnchor.connectedBody = GameObject.Find ("neck base").GetComponent<Rigidbody2D> ();
		Vector2 neckAnchor = new Vector2 (0f, -0.27f);
		thisAnchor.anchor = neckAnchor;
		Vector2 neckConnect = new Vector2 (0.004f, -0.27f);
		thisAnchor.connectedAnchor = neckConnect;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("w"))
			New_Neck ();
		if (Input.GetKeyDown ("w"))
			Connect_Neck ();
		if (Input.GetKeyDown ("w"))
			Move_Tag ();
		if (Input.GetKeyDown ("w"))
			New_Head ();
		if (Input.GetKeyDown ("w"))
		{
			GameObject neckNum = GameObject.FindWithTag ("ground");
			neckNum.GetComponent<Input_World_Reference> ().numOfNeck = neckNum.GetComponent<Input_World_Reference> ().numOfNeck + 1;
		}
	}
	void New_Neck() {
		GameObject oldHead = GameObject.FindWithTag ("CurrentHead");
		Destroy (oldHead);
		GameObject newNeck = Instantiate (Resources.Load ("neck head")) as GameObject;
		Transform oldNeck = GameObject.FindWithTag ("Current Neck").transform;
		newNeck.transform.position = oldNeck.position;
	}

	void Connect_Neck() {
		HingeJoint2D thisAnchor = GameObject.FindWithTag ("New Neck").gameObject.AddComponent<HingeJoint2D> ();
		thisAnchor.connectedBody = GameObject.FindWithTag ("Current Neck").GetComponent<Rigidbody2D> ();
		Vector2 neckAnchor = new Vector2 (0f, -0.27f);
		thisAnchor.anchor = neckAnchor;
		thisAnchor.autoConfigureConnectedAnchor = false;
		Vector2 neckConnect = new Vector2 (0.004f, 0.27f);
		thisAnchor.connectedAnchor = neckConnect;
	}
	void Move_Tag () {
		GameObject oldNeck = GameObject.FindWithTag ("Current Neck");
		oldNeck.gameObject.tag = "obsolete";
		GameObject newNeck = GameObject.FindWithTag ("New Neck");
		newNeck.gameObject.tag = "Current Neck";
	}
	void New_Head() {
		
		GameObject newHead = Instantiate (Resources.Load ("Llama Head")) as GameObject;
	}
}
