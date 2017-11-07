using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleSceneSwapper : MonoBehaviour {

	public string mode1Name;
	public string mode2Name;
	public string mode3Name;

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			SceneManager.LoadScene (mode1Name);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			SceneManager.LoadScene (mode2Name);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			SceneManager.LoadScene (mode3Name);
		}
	}
}
