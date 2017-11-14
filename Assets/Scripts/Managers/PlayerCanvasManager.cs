using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvasManager : MonoBehaviour {

	public GameObject popupPrefab;
	public Text healthText;

	private PlayerMovement myPlayer;

	// Use this for initialization
	void Start () {
		myPlayer = transform.parent.GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.eulerAngles = Vector3.zero;
		healthText.text = "" + myPlayer.hitpoints;
	}

	public void PopupMessage(string contents, float travelDur, float lingerDur, float scaleOverTravel){
		GameObject newPopup = Instantiate(popupPrefab, this.transform);
		newPopup.GetComponent<Text>().text = contents;
		PopupScript newPPS = newPopup.GetComponent<PopupScript>();
		newPPS.travelDuration = travelDur;
		newPPS.lingerDuration =  lingerDur;
		newPPS.scaleToReach = scaleOverTravel;
		newPPS.execute = true;
	}
}
