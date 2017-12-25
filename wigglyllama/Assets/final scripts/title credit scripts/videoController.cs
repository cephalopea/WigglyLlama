using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videoController : MonoBehaviour {

	void PlayMovie() {
		((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
	}

	// Use this for initialization
	void Start () {
		PlayMovie ();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
