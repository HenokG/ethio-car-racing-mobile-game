using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollectableItems : MonoBehaviour {

	public static float enemySpeed = 6f;

	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0, -1, 0) * enemySpeed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "MainCharacter") {
			Utililty.currentCoins++;
			gameObject.SetActive(false);
		}
	}
}