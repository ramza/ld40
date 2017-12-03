using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour {

	Rigidbody2D rb2d;
	AudioSource audio;
	public float speed = 3f;
	public CatsManager catManager;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		catManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<CatsManager> ();
		Destroy (gameObject, 7f);
	}


	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Cat") {
			catManager.removeFromCatList (col.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		rb2d.velocity = new Vector2 (-1, 0)*speed;
	}
}
