using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinManager : MonoBehaviour {

	public static WinManager instance;

	public int numOfKillsToWin;


	public Text WinText;
	PlayerMovement[] Players;


	// Use this for initialization
	void Start () {
		instance = this;
		GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
		Players = new PlayerMovement[playerObjects.Length];
		for (int i = 0; i < Players.Length; i++) {
			Players[i] = playerObjects[i].GetComponent<PlayerMovement>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Players.Length; i++) {
			if (Players[i].killCount >= numOfKillsToWin){
				DisplayWinmessage(i + 1);
			}
		}
	}

	void DisplayWinmessage(int playerInt, string method){
		//Debug.Log("Player " + playerInt + " has won via " + method);
		WinText.transform.parent.gameObject.SetActive(true);
		WinText.text = "Congrutalations player " + playerInt + "! You're the best at killing! Press R to restart and let your lesser pals have another shot.";
	}
}
