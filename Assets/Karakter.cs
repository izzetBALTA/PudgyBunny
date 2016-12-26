using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Karakter : MonoBehaviour {

	public float hiz,maxHiz, ziplamaGucu;
	public bool yerdemi,ciftZipla,android,sol,sag;


	Rigidbody2D agirlik;
	Animator anim;

	public int can, maxcan,havuc,altin;
	public GameObject[] canlar;
	public Text altinmiktar, havucmiktar;
	public AudioClip[] sesler;
	public GameObject androidpanel;

	void Start () {
		anim = GetComponent<Animator> ();
		agirlik = GetComponent<Rigidbody2D> ();
		can = maxcan;
		canSistemi ();
	}

	// Update is called once per frame
	void Update () {
		altinmiktar.text = "" + altin;
		havucmiktar.text = "" + havuc; 
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel (Application.loadedLevel);
		}
		if (Input.GetKeyDown(KeyCode.W) && yerdemi) {

			Ziplama ();    


		}        


		if (can<=0) {
			olme ();
		}

		if (android) {

			androidpanel.SetActive (true);

		}
		else {
			androidpanel.SetActive (false);
		}

	}

	void FixedUpdate(){
		float h = Input.GetAxis("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (hiz));
		anim.SetBool ("Yerde", yerdemi);
		if (android) {
			if (sol) {
				h = -1;
				transform.localScale = new Vector2 (-1, 1);
				transform.Translate (-h * hiz * Time.deltaTime, 0, 0);
			}
			if (sag) {
				h = 1;
				transform.localScale = new Vector2 (1, 1);
				transform.Translate (h * hiz * Time.deltaTime, 0, 0);


			}
			if (!sol && !sag) {
				h = 0;

			}

		} else {

			if (h > 0) {
				transform.Translate (h * hiz * Time.deltaTime, 0, 0);
			}
			if (h < 0) {
				transform.Translate (-h * hiz * Time.deltaTime, 0, 0);
			}
			//agirlik.AddForce (Vector3.right * h * hiz);

			if (h > 0.1f) {
				transform.localScale = new Vector2 (1, 1);
			}
			if (h < -0.1f) {
				transform.localScale = new Vector2 (-1, 1);
			}
			if (agirlik.velocity.x > maxHiz) {
				agirlik.velocity = new Vector2 (maxHiz, agirlik.velocity.y);

			}
			if (agirlik.velocity.x < -maxHiz) {
				agirlik.velocity = new Vector2 (-maxHiz, agirlik.velocity.y);
			}

		}
	}



	void olme(){
		Application.LoadLevel (Application.loadedLevel);

	}
	void OnCollisionEnter2D(Collision2D nesne) {
		if (nesne.gameObject.tag == "Tuzak") {
			can -= Random.Range (1,1);
			agirlik.AddForce ((Vector2.up * ziplamaGucu)/2);
			GetComponent<SpriteRenderer> ().color = Color.red;
			Invoke ("Duzelt", 0.5f);
			canSistemi ();
		}

		if(nesne.gameObject.tag == "Kapi") {
			Debug.Log (Application.loadedLevelName);
			int sonrakiLevel = int.Parse (Application.loadedLevelName) + 1;
			PlayerPrefs.SetInt (sonrakiLevel.ToString(), 1);
			Application.LoadLevel("Anamenü");

		}


	}

	void canSistemi() {
		for (int i = 0; i < maxcan; i++) {
			canlar [i].SetActive (false);
		}
		for (int i = 0; i < can; i++) {
			canlar [i].SetActive (true);
		}
	}
	void OnTriggerEnter2D(Collider2D nesne) {
		if (nesne.gameObject.tag == "Havuc") {
			havuc++;
			GetComponent<AudioSource> ().PlayOneShot (sesler[0]);
			Destroy (nesne.gameObject);
		}
		if (nesne.gameObject.tag == "Altin") {
			altin++;
			GetComponent<AudioSource> ().PlayOneShot (sesler[1]);
			Destroy (nesne.gameObject);
		}

		if (nesne.gameObject.tag == "Can") {
			if (can != maxcan) {
				can++;
				canSistemi ();
				GetComponent<SpriteRenderer> ().color = Color.green;
				Invoke ("Duzelt", 0.5f);
				Destroy (nesne.gameObject);
			}

		}
	}
	void Duzelt() {
		GetComponent<SpriteRenderer> ().color = Color.white;
	}
	public void Ziplama() {
		agirlik.AddForce (Vector2.up * ziplamaGucu);
	}
}

