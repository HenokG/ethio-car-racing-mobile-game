using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {
	public static float enemySpeed = 6f;
	public UiManager ui;
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0, -1, 0) * enemySpeed * Time.deltaTime);	
	}
	
	void OnCollisionEnter2D(Collision2D col){
		
		if(gameObject.tag == "firstInstructionInitiator"){
			ui.initiateInstruction(1);
		}
		else if(gameObject.tag == "secondInstructionInitiator"){
			ui.initiateInstruction(2);
		}
		else if(gameObject.tag == "thirdInstructionInitiator"){
			ui.initiateInstruction(3);
		}
		Destroy (gameObject);
	}
}