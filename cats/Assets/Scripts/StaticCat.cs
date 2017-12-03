using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCat : MonoBehaviour {

	AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player")
			audio.Play ();
	}
}
