using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinManager : MonoBehaviour {

	public static WinManager instance;

	public Transform parentCanvas;
	public Slider winSliderPrefab;
	public Image slidersBG;

	public int numOfKillsToWin;


	public Text WinText;
	PlayerMovement[] Players;
	Slider[] winSliders;


	// Use this for initialization
	void Start () {
		instance = this;
		GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
		Players = new PlayerMovement[playerObjects.Length];
		winSliders = new Slider[Players.Length];
		for (int i = 0; i < Players.Length; i++) {
			Players[i] = playerObjects[i].GetComponent<PlayerMovement>();
			winSliders[i] = Instantiate (winSliderPrefab, parentCanvas);
			winSliders[i].image.color = Players[i].GetComponent<SpriteRenderer>().color;
			///winSliders[i].colors.normalColor = Players[i].GetComponent<SpriteRenderer>().color;
			winSliders[i].minValue = 0;
			winSliders[i].maxValue = numOfKillsToWin;
			//winSliders[i].transform.Find("Background").GetComponent<Image>().color = winSliders[i].image.color;
		}
	}
	
	// Update is called once per frame
	void Update () {
		int bestPlayerKills = 0;
		for (int i = 0; i < Players.Length; i++) {
			if (Players[i].killCount > bestPlayerKills){
				// slidersBG.color = winSliders[i].image.color;
				bestPlayerKills = Players[i].killCount;
				}
			if (Players[i].killCount >= numOfKillsToWin){
				DisplayWinmessage(i + 1);
			}
			winSliders[i].value = Players[i].killCount;
            if (winSliders[i].image.sprite != Players[i].GetComponent<SpriteRenderer>().sprite)
                winSliders[i].image.sprite = Players[i].GetComponent<SpriteRenderer>().sprite;
        }
	}

	void DisplayWinmessage(int playerInt){
		//Debug.Log("Player " + playerInt + " has won via " + method);
		WinText.transform.parent.gameObject.SetActive(true);
		WinText.text = "Congrutalations player " + playerInt + "! You're the best at killing! Press R to restart and let your lesser pals have another shot.";
	}
}
