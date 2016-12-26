using UnityEngine;
using System.Collections;

public class KarakterAndroid : MonoBehaviour {

	Karakter kr;

	void Start () {
		kr = GetComponent<Karakter> ();
	}


	void Update () {

	}

	public void sol(){
		kr.sol = true;
	}

	public void sag(){
		kr.sag = true;
	}

	public void solUp(){
		kr.sol = false;
	}
	public void sagUp(){
		kr.sag = false;
	}


	public void zipla(){
		if (kr.yerdemi) {
			kr.Ziplama ();
		}
	}
}
