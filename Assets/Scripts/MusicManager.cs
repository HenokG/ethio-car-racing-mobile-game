using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	private AudioSource bgMusic;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		GetAudioSource ();
		PlayOrNotPlay ();
	}

	void GetAudioSource(){
		bgMusic = GetComponent<AudioSource>();
	}

	void PlayOrNotPlay(){
		if (Utililty.isSoundOn != 0) {
			bgMusic.Play ();
		} else {
			bgMusic.Stop();
		}
	}
	private static MusicManager instance = null;
	public static MusicManager Instance {
		get { return instance; }
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}

}