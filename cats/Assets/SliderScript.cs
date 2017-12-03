using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderScript : MonoBehaviour {

	public AudioSource bkgMusic;
	// Use this for initialization
	void Start () {
		
	}

	public void SetVolume(float vol){
		bkgMusic.volume = vol;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
