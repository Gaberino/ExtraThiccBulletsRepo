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
	public float p2StayTime;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (p1HoldTime >= timeObjHeldToWin || p2HoldTime >= timeObjHeldToWin) {
			//win via hold
			if (p1HoldTime > p2HoldTime)
				DisplayWinmessage(1, "holding the McGuffin");
			
			else
				DisplayWinmessage(2, "holding the McGuffin");
		} else if (p1Kills >= numOfKillsToWin || p2Kills >= numOfKillsToWin) {
			//win via kills
			if (p1Kills > p2Kills)
				DisplayWinmessage(1, "absolute slaughter!");

			else
				DisplayWinmessage(2, "absolute slaughter");
		} else if (p1StayTime >= timeInZoneToWin || p2StayTime >= timeInZoneToWin) {
			//win via king of the hill
			if (p1StayTime > p2StayTime)
				DisplayWinmessage(1, "capturing the point!");

			else
				DisplayWinmessage(2, "capturing the point!");
		}
	}

	void DisplayWinmessage(int playerInt, string method){
		Debug.Log("Player " + playerInt + " has won via " + method); 
	}
}
