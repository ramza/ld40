using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour {

	public Button resetButton;
	// Use this for initialization
	void Start () {
		resetButton.onClick.AddListener (delegate {
			OnResetButtonClick();
		});
	}

	void OnResetButtonClick(){
		SceneManager.LoadScene ("Start");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
