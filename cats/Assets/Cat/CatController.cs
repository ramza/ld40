using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour {

	Animator anim;
	bool walk = false;
	float timer = 0;
	Rigidbody2D rb2d;
	AudioSource audio;
	bool sex = false;
	string name = "cat";

	Vector2 velocity;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
		audio = GetComponent<AudioSource> ();
		velocity = new Vector2 (0, 0);
		int r = Random.Range (0, 5);
		if (r < 2)
			sex = true;
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Player") {
			audio.Play ();
		}
	}

	public bool GetSex(){
		return sex;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 5f) {
			anim.SetFloat ("x", 0);
			velocity = new Vector2 (0, 0);
			timer = 0;
			float r = Random.Range (0, 2);
			if (r < 1)
				walk = !walk;
				
			if (walk) {
				r = Random.Range (0, 2);
				if (r < 1) {
					anim.SetFloat ("x", -1);
					velocity = new Vector2 (-1, Random.Range(-1,1));
				} else {
					anim.SetFloat ("x", 1);
					velocity = new Vector2 (1, Random.Range(-1,1));
				}
			} else {
				anim.SetFloat ("x", 0);
				velocity = new Vector2 (0, 0);
			}
		}
		rb2d.velocity = velocity;
	}
}
