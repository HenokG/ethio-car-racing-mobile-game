using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public static float enemySpeed = 6f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0, -1, 0) * enemySpeed * Time.deltaTime);
	}
}