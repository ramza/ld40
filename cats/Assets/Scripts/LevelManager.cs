using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    //Timescale would stay at zero if reset from pause screen. This was the fastest fix I could think of.
    void Start ()
    {
        Time.timeScale = 1;
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

	public void ExitGame(){
		print ("Exit Game");
		Application.Quit ();
	}
}
