using UnityEngine;
using System.Collections;

public class PoliceController : MonoBehaviour {
	
	public static float policeSpeed = 6f;
	public int number = 1;
	int LeftOrRight;
	// Use this for initialization
	void Start () {
		if (this.transform.position.x > 0) {
			LeftOrRight = -1;
		} else {
			LeftOrRight = 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0, -1, 0) * policeSpeed * Time.deltaTime);

		if (this.transform.position.y < 2.9f && number < 14) {
				this.transform.Translate(new Vector3(LeftOrRight, 0, 0) * 3 * Time.deltaTime);
			number++;
		}
	}
}