using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimRenderer : MonoBehaviour {

	//public PlayerInput player;
	public PlayerInput myplayer;
	public GameObject playerPrefab;
	public GameObject myAim;

	// Use this for initialization
	void Start () {
		myplayer = playerPrefab.GetComponent<PlayerInput> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (myplayer.rightStickInput.magnitude > 0) {
			if (myAim.activeSelf == false) {
				myAim.gameObject.SetActive (true);
			}
		} else{
			myAim.gameObject.SetActive (false);
		}
	}
}
