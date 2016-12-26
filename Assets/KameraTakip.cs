using UnityEngine;
using System.Collections;

public class KameraTakip : MonoBehaviour {

	public Transform karakter;
	public float x,y;

	void Start () {
		karakter = GameObject.FindGameObjectWithTag ("Player").transform;
	}


	void Update () {
		transform.position = new Vector3 (karakter.position.x,karakter.position.y,-10);
	}
}

