using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelGit : MonoBehaviour {


	void Start () {
	
	}
	

	void Update () {
	
	}
	public void leveller(int levelid){
		Application.LoadLevel (levelid);
	}
	public void herseyisil() {
		PlayerPrefs.DeleteAll ();
		Application.LoadLevel (Application.loadedLevel);
	}

}
