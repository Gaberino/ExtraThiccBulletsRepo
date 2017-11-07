using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimplerSceneSwapper : MonoBehaviour {

	public string targetSceneName;
	public string inputButtonName;

	void Update(){
		if (Input.GetButtonDown (inputButtonName)) {
			SceneManager.LoadScene (targetSceneName);
		}
	}

}
