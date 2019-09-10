using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

	public Canvas PlayAfterPause;
	public Button PauseButton;
	public Text scoreText;
	public Text coinText;
	public Canvas firstInstruction;
	public Canvas secondInstruction;
	public Canvas thirdInstruction;
	int score;
	int isFirstTime;
	bool gameOver;
	private GameObject musicplayer;

	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteAll ();
		Utililty.currentCoins = 0;
		firstInstruction.enabled = false;
		secondInstruction.enabled = false;
		thirdInstruction.enabled = false;
	
		if(!PlayerPrefs.HasKey("isFirstTime")){
			PlayerPrefs.SetInt("isFirstTime", 1);
			PlayerPrefs.SetInt("totalCoinCount", 0);
			Utililty.currentCoins = 0;
		}
		Utililty.isFirstTime = PlayerPrefs.GetInt("isFirstTime");
		PlayAfterPause.enabled = false;

        gameOver = false;
		score = 0;
		InvokeRepeating ("scoreUpdate", 1.0f, 0.6f);

		if (Utililty.isSoundOn == 1) {
			AudioListener.pause = false;
		} else if (Utililty.isSoundOn == 0) {
			AudioListener.pause = true;
		}
		if (GameObject.FindGameObjectWithTag ("bgmusic") != null) {
			musicplayer = GameObject.FindGameObjectWithTag("bgmusic");
			musicplayer.SetActive(false);
		}


		if (Utililty.isFirstTime == 0) {
			GameObject f_initiators = GameObject.FindGameObjectWithTag("firstInstructionInitiator");
			GameObject s_initiators = GameObject.FindGameObjectWithTag("secondInstructionInitiator");
			GameObject t_initiators = GameObject.FindGameObjectWithTag("thirdInstructionInitiator");
			Destroy(f_initiators);
			Destroy(s_initiators);
			Destroy(t_initiators);
			Utililty.currentCoins = PlayerPrefs.GetInt("totalCoinCount");
		}

	}

	public void initiateInstruction(int instructionNumber){

		if (Utililty.isFirstTime == 1) {
			AudioListener.volume = 0;
			if(instructionNumber == 1){
				firstInstruction.enabled = true;
			}	
			else if(instructionNumber == 2){
				secondInstruction.enabled = true;
			}
			else if(instructionNumber == 3){
				thirdInstruction.enabled = true;
			}
			Time.timeScale = 0;
		}
	}

	public void destroyInstruction(int instructionNumber){

		AudioListener.volume = 1;
		if(instructionNumber == 1){
			firstInstruction.enabled = false;
		}
		else if(instructionNumber == 2){
			secondInstruction.enabled = false;
		}
		else if(instructionNumber == 3){
			thirdInstruction.enabled = false;
		}
		Time.timeScale = 1;
	}

	void scoreUpdate(){
		if (!gameOver) {
			score++;
		}
	}

	public void updateCoinCount(){
		coinText.text = "" + Utililty.currentCoins;
	}

	public void gameOverF(){
		Utililty.isFirstTime = 0;
		PlayerPrefs.SetInt("isFirstTime", 0);
		Utililty.currentScore = int.Parse(scoreText.text);
		if (Utililty.currentScore > Utililty.highScore) {
			Utililty.highScore = Utililty.currentScore;
		}
		PlayerPrefs.SetInt ("totalCoinCount", Utililty.currentCoins);
		PlayerPrefs.SetInt ("HighestScore", Utililty.highScore);
		Application.LoadLevel ("Game_Over");
		musicplayer.SetActive(true);

	}

	public void replay(){
		Application.LoadLevel (Application.loadedLevel);
	}

	public void menu(){
		Application.LoadLevel ("Game_Menu");
	}
		
	// Update is called once per frame
	void Update () {
		scoreText.text = ""+score;
		updateCoinCount ();
		if (int.Parse(scoreText.text) > 15 && int.Parse(scoreText.text) < 30) {
            //EnemyController.enemySpeed = 10f;
            PoliceController.policeSpeed = 7f;
            BlueCarController.policeSpeed = 7f;
            TrackMove.CarSpeed = 0.5f;
		}
		else if (int.Parse(scoreText.text) > 30 && int.Parse(scoreText.text) < 45) {
            //EnemyController.enemySpeed = 11f;
            PoliceController.policeSpeed = 8f;
            BlueCarController.policeSpeed = 8f;
        }
		else if (int.Parse(scoreText.text) > 45) {
            EnemyController.enemySpeed = 7f;
            PoliceController.policeSpeed = 9f;
            BlueCarController.policeSpeed = 9f;
        }
	}

	public void Pause(){
		Time.timeScale = 0;
		AudioListener.pause = true;
		PlayAfterPause.enabled = true;
		PauseButton.enabled = false;
	}

	public void playAfterPauseFunction(){
		Time.timeScale = 1;
		AudioListener.pause = false;
		PlayAfterPause.enabled = false;
		PauseButton.enabled = true;
	}
}