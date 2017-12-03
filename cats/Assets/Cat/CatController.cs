using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour {

	Animator anim;
	bool walk = false;
	float timer = 0;
	Rigidbody2D rb2d;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
		audio = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Player") {
			print ("cats meow");
			audio.Play ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 5f) {
			timer = 0;
			float r = Random.Range (0, 2);
			if (r < 1)
				walk = !walk;
				
			if (walk) {
				r = Random.Range (0, 2);
				if (r < 1) {
					anim.SetFloat ("x", -1);
					rb2d.velocity = new Vector2 (-1, 0);
				} else {
					anim.SetFloat ("x", 1);
					rb2d.velocity = new Vector2 (1, 0);
				}
			} else {
				anim.SetFloat ("x", 0);
				rb2d.velocity = new Vector2 (0, 0);
			}
		}
	}
}
