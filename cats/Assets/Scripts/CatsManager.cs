using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CatsManager : MonoBehaviour {

	public GameObject textPanel;
	public Text textBox;

	public AudioSource phoneAudio;
	public AudioSource sirenAudio;

	public GameObject dog;

	GameObject[] catArray;
	List<GameObject> catList;
	float timer = 0;
	public Text catCount;
	public Text goalText;
	float offset = 1;
	int totalCats = 0;
	int MAXCATS = 300;

	int counter = 0;
	int catTrigger;

	float textTimer = 0;


	int[] goals = new int[] { 20, 60, 100, 150, 200, 300, 600,1000,2000,3000 };
	string[] dialogue = new string[] {"Hey! I thought I told you to stop making those cats. Enough already, I'm sick of your weird behavior.", 
									   "What is your problem? I've asked you to please stop it with the cats!You do realize just how utterly ridiculous all this is don't you?",
										"REALLY?! This is way too many cats! I'm gonna call the cops! I will, I'll have you arrested for making all those cats.",
										"Now you've really made me angry. You've left me no choice but to leg my dogs loose on you! They'll take care of your annoying cats!",
										"I dit it! I called the cops. You see what you made me do? You're going to jail. I hope you're happy with yourself. I just can't believe people like you.",
										"You're dispicable. Where are those cops? How come you aren't behind bars? ARGGG!!!",
										 "You have to be the worst neighbor who'se ever lived. I'm going to march over there and punch you right in the nose!",
											"There's never been a worse villain in all of history than you with your stupid cat magic. I'll make you pay for this!",
												"AHHHHHH! ARGHG! *%^#$% #^&*& @#$%^ you little #$%^$!"};

	// Use this for initialization
	void Start () {
		catTrigger = goals [0];
		catList = new List<GameObject> ();
		textPanel.SetActive (false);
		goalText.text = "Goals: " + goals [0].ToString();
		catCount.text = "Total Cats: " + totalCats;
	}

	void DogSpawn(int total){
		for (int i = 0; i < total; i++) {
			Instantiate (dog, new Vector3 (8, Random.Range (-7, 7), 0), Quaternion.identity);	
		}
	}

	public void findAllCats(){
		catArray = GameObject.FindGameObjectsWithTag ("Cat");
	}

	public void addToCatList(GameObject cat){
		catList.Add (cat);
	}

	public void removeFromCatList(GameObject cat) {
		catList.Remove (cat);
		Destroy (cat.gameObject);
	}

	// Update is called once per frame
	void Update () {
		totalCats = GameObject.FindGameObjectsWithTag ("Cat").Length;
		catCount.text = "Total Cats: " + totalCats;
		textTimer++;
		if (textTimer > 1000f) {
			textTimer = 0;
			textPanel.SetActive (false);
			if (counter >= goals.Length-1)
				SceneManager.LoadScene("End");
		}
		if (totalCats >= catTrigger) {
			
			if (counter == 1 || counter == 3) {
				Debug.Log ("Counter = 1");
				DogSpawn (3);
			}
			textTimer = 0;
			catTrigger *= 3;
			textBox.text = dialogue [counter];
			if (counter > 3)
				sirenAudio.Play ();
			counter++;

			catTrigger = goals [counter];
			goalText.text = "Goals: " + catTrigger.ToString();
			textPanel.SetActive (true);
			phoneAudio.Play ();
		}

		timer += Time.deltaTime;
		if (timer > 20f && totalCats < MAXCATS) {
			textPanel.SetActive (false);
			timer = 0;
			catArray = GameObject.FindGameObjectsWithTag ("Cat");
			foreach (GameObject cat in catArray) {
				CatController newCat = cat.gameObject.GetComponent<CatController> ();
				Vector3 spawnPosition = new Vector3 (cat.transform.position.x + Random.Range (-offset, offset), cat.transform.position.y + Random.Range (-offset, offset), 0);
				Instantiate (newCat, spawnPosition, Quaternion.identity);
				totalCats++;
			}
			catCount.text = "Total Cats: " + totalCats;
		}
	}
}
