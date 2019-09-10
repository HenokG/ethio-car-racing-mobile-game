using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour {

	public GameObject[] cars;
	int carNo;
	public float maxPos = 1.0f;
	public float delayTimer = 2f;
	float timer;
	// Use this for initialization
	void Start () {
		if (Utililty.isFirstTime == 1) {
			timer = 3.0f;
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
			Vector3 carPos = camera.ScreenToWorldPoint (v3);
			Vector2 carPosReal = new Vector2(v3.x, carPos.y);
			carNo = Random.Range(0, 5);
			Instantiate (cars[carNo], carPosReal, transform.rotation);
			timer = delayTimer;
		}
	}
}
