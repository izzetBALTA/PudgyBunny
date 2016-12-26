using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Levelbuton : MonoBehaviour {


	void Start () {
	
		if (gameObject.name == "1") {
			GetComponent<Button> ().interactable = true;
		
		} else {
			if (PlayerPrefs.GetInt (gameObject.name) ==1) {
				GetComponent<Button> ().interactable = true;
			} else {
				
				GetComponent<Button> ().interactable = false;
			}
		}
	}
	

	void Update () {
	
	}
}
