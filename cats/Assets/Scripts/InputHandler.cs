using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour {

	public GameObject spawnObject;
	public List<GameObject> catList;
	public List<GameObject> catObjects;
	public Camera cam;
	float timer = 2f;
	public Text catCount;

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
			spawnObject = catList [Random.Range (0, catList.Count)];
		
			Instantiate(spawnObject,new Vector3(worldPos.x, worldPos.y, 0),Quaternion.identity);
			catObjects.Add (spawnObject);
			catCount.text = "Total Cats: " + catObjects.Count;
			Debug.Log(worldPos);

		}
		
	}
}
