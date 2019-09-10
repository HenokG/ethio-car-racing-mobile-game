using UnityEngine;
using System.Collections;

public class TrackMove : MonoBehaviour {

	public static float CarSpeed = .4f;
	Vector2 offset;

	// Use this for initialization
	void Start () {
		offset = new Vector2 (0, Time.time * CarSpeed);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;
	}
	
	// Update is called once per frame
	void Update () {
		offset = new Vector2 (0, Time.time * CarSpeed);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;
	}
}
