using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public Canvas QuitMenu;
	public Button Quit;
	public Button HighScore;
	public Button Play;
	// Use this for initialization
	void Start () {

		QuitMenu = QuitMenu.GetComponent<Canvas> ();
		Quit = Quit.GetComponent<Button> ();
		Play = Play.GetComponent<Button> ();
		HighScore = HighScore.GetComponent<Button> ();
		QuitMenu.enabled = false;
		if(PlayerPrefs.HasKey("HighestScore")){
			Utililty.highScore = PlayerPrefs.GetInt ("HighestScore");
		}
		else{
			Utililty.highScore = 1;
		};
		if(PlayerPrefs.HasKey("isSoundOn")){
			Utililty.isSoundOn = PlayerPrefs.GetInt ("isSoundOn");
		}
		else{
			PlayerPrefs.SetInt("isSoundOn", 1);
			Utililty.isSoundOn = PlayerPrefs.GetInt("isSoundOn");
		};

		if(PlayerPrefs.HasKey("inputMethod")){
			Utililty.inputMethod = PlayerPrefs.GetInt ("inputMethod");
		}
		else{
			PlayerPrefs.SetInt("inputMethod", 2);
			Utililty.inputMethod = PlayerPrefs.GetInt("inputMethod");
		};
        if (!PlayerPrefs.HasKey("totalCoinCount")) {
            PlayerPrefs.SetInt("totalCointCount", 0);
        }
        Utililty.currentCoins = PlayerPrefs.GetInt("totalCoinCount");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			exit();
		}
	}

	public void exit(){
		QuitMenu.enabled = true;
		HighScore.enabled = false;
		Quit.enabled = false;
		Play.enabled = false;
		
	}
	public void PlayFunction(){
		Application.LoadLevel ("Level_One");
	}

	public void SettingFunction(){
		Application.LoadLevel ("Setting");
	}

	public void About(){
		Application.LoadLevel ("About");
	}
	public void NoQuit(){
		QuitMenu.enabled = false;
		HighScore.enabled = true;
		Quit.enabled = true;
		Play.enabled = true;
	}
	public void YesQuit(){
		Application.Quit ();
	}
	public void HighScoreFunction(){
		Application.LoadLevel ("High_Score");
	}	

}
