using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighUiManager : MonoBehaviour {

	public Text HighScoreText;
	public Text TotalCoinCount;

	// Use this for initialization
	void Start () {
		HighScoreText = HighScoreText.GetComponent<Text> ();
		HighScored ();
		TotalCoinCount.text = " X " + Utililty.currentCoins;
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

	public void HighScored(){
		if (Utililty.highScore > Utililty.currentScore) {
			HighScoreText.text = Utililty.highScore.ToString();
		} else {
			Utililty.highScore = Utililty.currentScore;
			HighScoreText.text = Utililty.highScore.ToString();
		}
	}

	public void backToMenu(){
		Application.LoadLevel ("Game_Menu");
	}
}