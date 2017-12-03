using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour {

	public CatsManager catManager;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Cat") {
			catManager.removeFromCatList (col.gameObject);
		} 
	}
}
