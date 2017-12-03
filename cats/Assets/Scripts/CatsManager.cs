using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatsManager : MonoBehaviour {

	public GameObject textPanel;
	public Text textBox;

	public AudioSource phoneAudio;

	List<GameObject> catList;
	float timer = 0;
	public Text catCount;
	float offset = 1;
	int totalCats = 0;
	int MAXCATS = 300;

	int counter = 0;
	int catTrigger = 10;

	float textTimer = 0;

	string[] dialogue = new string[] {"Hey! I thought I told you to stop making those cats. Enough already.", 
									   "What is your problem? I've asked you to please stop it with the cats! You're ridiculous.",
										"REALLY?! This is way too many cats! No more cats. I'm gonna call the cops if you make another cat.",
										"I dit it! I called the cops. You're going to jail. I hope you're happy with yourself. I just can't believe people like you."};

	// Use this for initialization
	void Start () {
		catList = new List<GameObject> ();
		textPanel.SetActive (false);
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
		textTimer += Time.deltaTime;
		if (textTimer > 10f) {
			textTimer = 0;
			textPanel.SetActive (false);
		}
		if (totalCats > catTrigger) {
			textTimer = 0;
			catTrigger *= 3;
			textBox.text = dialogue [counter];
			counter++;
			textPanel.SetActive (true);
			phoneAudio.Play ();
		}

		timer += Time.deltaTime;
		if (timer > 10f && totalCats < MAXCATS) {
			textPanel.SetActive (false);
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
