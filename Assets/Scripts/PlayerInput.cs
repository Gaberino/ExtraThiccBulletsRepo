using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerInput : MonoBehaviour {

	public int playerNum;

	public Vector2 leftStickInput = Vector2.zero;
	public Vector2 rightStickInput = Vector2.zero;
	public bool shootButtonHeld = false;
	public bool dashButtonPressed = false;
	public bool weaponSwapButtonPressed = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var inputDevice = (InputManager.Devices.Count > playerNum) ? InputManager.Devices[playerNum] : null;
		if (inputDevice == null) {
			//do nothing
		} 
		else { //set inputs
			leftStickInput = new Vector2(inputDevice.LeftStick.X, inputDevice.LeftStick.Y);

			rightStickInput = new Vector2(inputDevice.RightStick.X, inputDevice.RightStick.Y);

			shootButtonHeld = inputDevice.RightBumper.IsPressed;

			dashButtonPressed = inputDevice.LeftBumper.WasPressed;

			weaponSwapButtonPressed = inputDevice.Action1.WasPressed;
		}
	}
}
