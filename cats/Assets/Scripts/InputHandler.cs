using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

	public GameObject spawnObject;
	public List<GameObject> catList;
	public Camera cam;
	float timer = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if(timer > 2f && Input.GetMouseButton(0)){

			timer = 0;
			var screenPos = Input.mousePosition;
			var worldPos = cam.GetComponent<Camera>().ScreenToWorldPoint(screenPos);
		
			Instantiate(spawnObject,new Vector3(worldPos.x, worldPos.y, 0),Quaternion.identity);
			Debug.Log(worldPos);

		}
		
	}
}
