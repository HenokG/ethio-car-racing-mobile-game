using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour {

	public GameObject coin;
	public float maxPos = 1.0f;
	public float delayTimer = 3f;
	float timer;
	// Use this for initialization
	void Start () {
		if (Utililty.isFirstTime == 1) {
			timer = 6.0f;
		}
		else{
			timer = delayTimer;
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <=0) {
			Vector3 v3 = new Vector3(Random.Range(-0.95f, 1.0f), (float)Screen.height, transform.position.z);
			Camera camera = Camera.main;
			Vector3 coinPos = camera.ScreenToWorldPoint (v3);
			Vector2 coinPosReal = new Vector2(v3.x, coinPos.y);
			Instantiate (coin, coinPosReal, transform.rotation);
			timer = delayTimer;
		}
	}
}
