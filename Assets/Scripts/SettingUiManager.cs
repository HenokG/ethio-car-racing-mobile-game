using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingUiManager : MonoBehaviour {

	public Text soundDescription;
	public Text inputMethod;

	// Use this for initialization
	void Start () {
		if (Utililty.isSoundOn == 1) {
			soundDescription.text = "ON";
		} else if (Utililty.isSoundOn == 0) {
			soundDescription.text = "OFF";
		}
		if (Utililty.inputMethod == 1) {
			inputMethod.text = "Tilt";
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			backToMenu();
		}
	}

	public void SoundButtonClicked(){
		if (Utililty.isSoundOn == 1) {
			soundDescription.text = "OFF";
			PlayerPrefs.SetInt("isSoundOn", 0);
			Utililty.isSoundOn = PlayerPrefs.GetInt("isSoundOn");
			AudioListener.pause = true;
		} else if(Utililty.isSoundOn == 0){
			soundDescription.text = "ON";
			PlayerPrefs.SetInt("isSoundOn", 1);
			Utililty.isSoundOn = PlayerPrefs.GetInt("isSoundOn");
			AudioListener.pause = false;
		}
	}

	public void TouchClicked(){
		inputMethod.text = "Touch";
		PlayerPrefs.SetInt("inputMethod", 2);
		Utililty.inputMethod = PlayerPrefs.GetInt("inputMethod");
	}

	public void TiltClicked(){
		inputMethod.text = "Tilt";
		PlayerPrefs.SetInt("inputMethod", 1);
		Utililty.inputMethod = PlayerPrefs.GetInt("inputMethod");
	}

	public void backToMenu(){
		Application.LoadLevel ("Game_Menu");
	}
}