using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlController : MonoBehaviour {

	Animator anim;
	public float walkSpeed = 1f;
	Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		anim.SetFloat ("x", x);
		anim.SetFloat ("y", y);
		Vector2 velocity = new Vector2 (x, y);
		rb2d.velocity = velocity*walkSpeed;
	}
}
