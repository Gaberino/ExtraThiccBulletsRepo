using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCooldownVisualizer : MonoBehaviour {

	private float chargeTime = 1;
	private float currentCharge = 1;

	public Color startChargingColor;
	public Color endChargingColor;
	public Color fullyChargedColor;

	private SpriteRenderer mySR;
	// Use this for initialization
	void Start () {
		mySR = this.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentCharge < chargeTime) {

			currentCharge += Time.deltaTime;
			mySR.color = Color.Lerp (startChargingColor, endChargingColor, currentCharge /  chargeTime);
		}
		else {
			if (mySR.color != fullyChargedColor)
				mySR.color = fullyChargedColor;
		}
	}

	public void ResetCharge(float time) {
		chargeTime = time;
		currentCharge = 0;
	}
}
