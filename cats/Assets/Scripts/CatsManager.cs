using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatsManager : MonoBehaviour {

	List<GameObject> catList;
	float timer = 0;
	public Text catCount;
	float offset = 1;
	int totalCats = 0;
	int MAXCATS = 300;

	// Use this for initialization
	void Start () {
		catList = new List<GameObject> ();
	}

	public void addToCatList(GameObject cat){
		catList.Add (cat);
		totalCats++;
		catCount.text = "Total Cats: " + totalCats;
	}

	public void removeFromCatList(GameObject cat) {
		catList.Remove (cat);
		totalCats--;
		catCount.text = "Total Cats: " + totalCats;
		print ("removed from cat list");
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 10f && totalCats < MAXCATS) {
			timer = 0;
			foreach (GameObject cat in catList) {
				CatController newCat = cat.gameObject.GetComponent<CatController> ();
				Instantiate (newCat, new Vector3 (cat.transform.position.x + Random.Range (-offset, offset), cat.transform.position.y + Random.Range (-offset, offset), 0), Quaternion.identity);
				totalCats++;
			}
			catCount.text = "Total Cats: " + totalCats;
		}
	}
}
