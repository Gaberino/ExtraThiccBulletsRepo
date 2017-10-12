using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeObject : MonoBehaviour {

	public ShotModifier[] shotModifiers;

	public float chargeTime;
	private float currentCharge;

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

	void OnTriggerEnter2D(Collider2D other) {
		if (currentCharge >= chargeTime) {
			if (other.tag == "Player") {
				other.GetComponent<SpaceGun> ().currentShotMod = shotModifiers [Random.Range (0, shotModifiers.Length)];
				currentCharge = 0f;
			}
		}
	}
}
