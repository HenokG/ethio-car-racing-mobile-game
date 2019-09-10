using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

	public Text TotalCoinCount;
	public Text currentScore;
	public Text HighScore;

	// Use this for initialization
	void Start () {
		Utililty.currentCoins = PlayerPrefs.GetInt ("totalCoinCount");
		TotalCoinCount.text = " X " + Utililty.currentCoins;
		currentScore.text = Utililty.currentScore.ToString();
		HighScore.text = Utililty.highScore.ToString();
        EnemyController.enemySpeed = 6f;
        BlueCarController.policeSpeed = 6f;
        PoliceController.policeSpeed = 6f;
        TrackMove.CarSpeed = 0.4f;
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

	public void replay(){
		Application.LoadLevel ("Level_One");
	}
}
