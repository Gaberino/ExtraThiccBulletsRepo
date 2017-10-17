using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour {

	public static WinManager instance;

	public int numOfKillsToWin;
	public int p1Kills;
	public int p2Kills;

	public float timeObjHeldToWin;
	public float p1HoldTime;
	public float p2HoldTime;
	public float timeInZoneToWin;
	public float p1StayTime;
	public float p2StayTIme;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (p1HoldTime >= timeObjHeldToWin || p2HoldTime >= timeObjHeldToWin) {
			//win via hold
		} else if (p1Kills >= numOfKillsToWin || p2Kills >= numOfKillsToWin) {
			//win via kills
		} else if (p1StayTime >= timeInZoneToWin || p2StayTIme >= timeInZoneToWin) {
			//win via king of the hill
		}
	}

	void DisplayWinmessage(int playerInt, string method){
		Debug.Log("Player " + playerInt + " has won via " + method); 
	}
}
