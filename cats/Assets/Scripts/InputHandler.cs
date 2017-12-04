using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour {

	private Slider volumeSlider;
	AudioSource audio;
	public AudioSource bkgMusic;
	public Image cooldownBar; 
	public GameObject spawnObject;
	public List<GameObject> catList;
	public CatsManager catManager;
	public Camera cam;
    public Canvas menuCanvas;
	float timer = 2f;
    bool menuActive = false;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}

	void ValueChange(){
		bkgMusic.volume = volumeSlider.value;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
            if (!menuActive)
            {
                Canvas m = Instantiate(menuCanvas);

				volumeSlider = m.GetComponentInChildren<Slider> ();
				volumeSlider.onValueChanged.AddListener(delegate {ValueChange();});
                menuActive = true;
                Time.timeScale = 0;
            } else
            {
                Destroy(GameObject.FindGameObjectWithTag("Menu"));
                menuActive = false;
                Time.timeScale = 1;
            }
		}

		timer += Time.deltaTime;
		if(timer < 2)
			cooldownBar.transform.localScale = new Vector2 (timer / 2, 1);

		if(timer > 2f && Input.GetMouseButton(0)){

			timer = 0;
			var screenPos = Input.mousePosition;
			var worldPos = cam.GetComponent<Camera>().ScreenToWorldPoint(screenPos);
			spawnObject = catList [Random.Range (0, catList.Count)];
		
			Instantiate(spawnObject,new Vector3(worldPos.x, worldPos.y, 0),Quaternion.identity);
			audio.Play ();
			catManager.addToCatList (spawnObject as GameObject);

		}
		
	}
}
