using UnityEngine;

public class CarController : MonoBehaviour {

	public float carSpeed;
	public float maxPos = 1.8f;

	Vector3 position;
	public UiManager ui;

	bool isPlatformAndroid = false;
	Rigidbody2D mainCar;
	
	// Use this for initialization
	void Start () {

		mainCar = GetComponent<Rigidbody2D> ();

		position = transform.position;
		#if UNITY_ANDROID
				isPlatformAndroid = true;
		#else
				isPlatformAndroid = false;
		#endif
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlatformAndroid) {
			if(Utililty.inputMethod == 1){
				accelerometerMove();
			}
			else if (Utililty.inputMethod == 2){
				TouchMove();
			}
		} else {
			position.x += Input.GetAxis ("Horizontal") * carSpeed * Time.deltaTime;
			position.x = Mathf.Clamp(position.x, -0.95f, 1.0f);
			transform.position = position;
		}

		position = transform.position;
		position.x = Mathf.Clamp(position.x,-0.95f, 1.0f);
		transform.position = position;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Enemy Car") {
			gameObject.SetActive (false);
			ui.gameOverF ();
		}
	}

	//For Android
	public void MoveLeft_4Android(){
		mainCar.velocity = new Vector2 (-carSpeed, 0);
	}
	public void MoveRight_4Android(){
		mainCar.velocity = new Vector2 (carSpeed, 0);
	}
	public void Stop(){
		mainCar.velocity = Vector2.zero;
	}

	public void TouchMove ()
	{
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			float middle = Screen.width / 2;

			if (touch.position.x < middle && touch.phase == TouchPhase.Began) {
				MoveLeft_4Android ();
			} else if (touch.position.x > middle && touch.phase == TouchPhase.Began) {
				MoveRight_4Android ();
			} else {
				
			}
		} else {
			Stop();
		}
	}

	public void accelerometerMove(){
		float x = Input.acceleration.x;
		if (x > 0.1f) {
			MoveRight_4Android ();
		} else if (x < -0.1f) {
			MoveLeft_4Android();
		} else {
			Stop();
		}
	}
}