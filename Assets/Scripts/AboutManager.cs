using UnityEngine;
using System.Collections;

public class AboutManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

		if (Utililty.isSoundOn == 1) {
			AudioListener.pause = false;
		} else if (Utililty.isSoundOn == 0) {
			AudioListener.pause = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			backToMenu();
		}		
	}

	public void backToMenu(){
		Application.LoadLevel ("Game_Menu");
	}

	public void rohaSoftwares(){
		Application.OpenURL (Utililty.rohaSoftwaresURL);
	}
}