using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public static MenuManager instance;

	public int chosenGameMode = 0; //0 is DanG, 1 is PowerBall

	public RectTransform[] screens;
	public float screenLerpSpeed = 0.17f;

	private int currentScreen = 0;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (screens [currentScreen].anchoredPosition.x != 0) {
			float moveAmount = Mathf.Lerp (screens [currentScreen].anchoredPosition.x, 0, screenLerpSpeed);
			moveAmount -= screens [currentScreen].anchoredPosition.x;
			for (int i = 0; i < screens.Length; i++) {
				screens [i].anchoredPosition += Vector2.right * moveAmount;
			}
		}
	}

	public void SetCurrentScreen(int newScreen){
		currentScreen = newScreen;
	}

	public void SetGameMode(int newGamemode){
		chosenGameMode = newGamemode;
	}

	public void QuitGame(){
		Debug.Log ("quitting");
		Application.Quit ();
	}
}
