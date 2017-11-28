using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InControl;

public class PlayerReadyObject : MonoBehaviour {

	public SubModifier dashReference;
	public GameObject dashImage;
	public SubModifier shieldReference;
	public GameObject shieldImage;
	public SubModifier teleReference;
	public GameObject teleImage;
	public SubModifier chosenSubmodifier;

	private PlayerInput myInput;

	public int playerID = 0;
	public bool controllerAvail = false;
	public bool lockedIn = false;

	public int viewingMod {
		get {
			return a_viewingMod;
		}
		set {
			if (value < 0) a_viewingMod = 2;
			else if (value > 2) a_viewingMod = 0;
			else a_viewingMod = value;
		}
	}
	private int a_viewingMod = 0;

	public Color notLockedColor;
	public Color lockedColor;
	private Image bgImage;

//	bool upHit = false;
//	bool downHit = false;
//	bool submitHit = false;
	// Use this for initialization
	void Start () {
		chosenSubmodifier = dashReference;

		bgImage = this.GetComponent<Image>();

		myInput = this.GetComponent<PlayerInput>();

		myInput.playerNum = playerID;
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager.Devices.Count >= playerID){
			controllerAvail = true;

			//upHit = InputManager.Devices[playerID - 1].DPadUp.WasPressed;
			//downHit = InputManager.Devices[playerID - 1].DPadDown.WasPressed;
			//submitHit = InputManager.Devices[playerID - 1].Action1.WasPressed;
		}
		else {
			controllerAvail = false;
		}

		if (!lockedIn){ //selection thingy
			if (bgImage.color != notLockedColor)
				bgImage.color = notLockedColor;

			if (myInput.weaponSwapButtonPressed){
				viewingMod += 1;
			}
			if (myInput.circlePressed){
				if (viewingMod == 0)
					chosenSubmodifier = dashReference;
				else if (viewingMod == 1)
					chosenSubmodifier = shieldReference;
				else if (viewingMod == 2)
					chosenSubmodifier = teleReference;

				lockedIn = true;
			}
			if (viewingMod == 0){
				dashImage.SetActive(true);
				shieldImage.SetActive(false);
				teleImage.SetActive(false);
			}
			else if (viewingMod == 1){
				dashImage.SetActive(false);
				shieldImage.SetActive(true);
				teleImage.SetActive(false);
			}
			else if (viewingMod == 2){
				dashImage.SetActive(false);
				shieldImage.SetActive(false);
				teleImage.SetActive(true);
			}

		}
		else {
			if (bgImage.color != lockedColor)
				bgImage.color = lockedColor;

			if (myInput.circlePressed){
				lockedIn = false;
			}
		}
	}
}
