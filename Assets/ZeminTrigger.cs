using UnityEngine;
using System.Collections;

public class ZeminTrigger : MonoBehaviour {

	Karakter kr;
	void Start () {
		kr = transform.root.gameObject.GetComponent<Karakter> ();
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(){
		kr.yerdemi = true;
	}

	void OnTriggerStay2D(){
		kr.yerdemi = true;
	}
	void OnTriggerExit2D(){
		kr.yerdemi = false;
	}
}
