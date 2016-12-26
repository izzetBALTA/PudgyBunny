using UnityEngine;
using System.Collections;

public class Tus : MonoBehaviour {

	public void bolum (int Anamenü) {
		Application.LoadLevel (Anamenü);
	}
	public void Exit () {
		Application.Quit ();
	}
}