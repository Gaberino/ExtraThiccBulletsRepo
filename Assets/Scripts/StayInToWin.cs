using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInToWin : MonoBehaviour {


	private Collider2D myCollider;

	GameObject currentGainingPlayer;
	int gainingPlayerID;
	bool pointContested = false;
	// Use this for initialization
	void Start () {
		myCollider = this.GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentGainingPlayer != null && !pointContested) {
			if (gainingPlayerID == 1) {
				//WinManager.instance.p1StayTime += Time.deltaTime;
			} else {
				//WinManager.instance.p2StayTime += Time.deltaTime;
			}
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.tag.Contains ("Player")) {
			if (currentGainingPlayer == null) {

				currentGainingPlayer = col.gameObject;
				gainingPlayerID = col.gameObject.GetComponent<PlayerMovement> ().playerNumber; //may need to change the script being grabbed here
			} else if (currentGainingPlayer != col.gameObject){
				pointContested = true;
			}
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.tag.Contains ("Player")) {

			currentGainingPlayer = null;
		}
	}
}
