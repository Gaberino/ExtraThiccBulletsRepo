using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimplerSceneSwapper : MonoBehaviour {

	public string targetSceneName;

	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadScene (targetSceneName);
		}
	}

}
