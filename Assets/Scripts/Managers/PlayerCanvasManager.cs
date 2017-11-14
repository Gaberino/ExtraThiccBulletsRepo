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
		healthText.text = "" + myPlayer.health;
		healthText.enabled = myPlayer.GetComponent<SpriteRenderer>().enabled;

		if (myPlayer.health == myPlayer.max_health && myPlayer.max_health != 1){
			healthText.color = Color.green;
		}
		else if (myPlayer.health == 1 && myPlayer.max_health != 1){
			healthText.color = Color.red;
		}
		else {
			healthText.color = Color.white;
		}
	}

	public void PopupMessage(string contents, float travelDur, float lingerDur, float distanceToTravel, float scaleOverTravel){
		GameObject newPopup = Instantiate(popupPrefab, this.transform);
		newPopup.GetComponent<Text>().text = contents;
		PopupScript newPPS = newPopup.GetComponent<PopupScript>();
		newPPS.travelDuration = travelDur;
		newPPS.lingerDuration =  lingerDur;
		newPPS.scaleToReach = scaleOverTravel;
		newPPS.relDistanceToTravel = distanceToTravel;
		newPPS.execute = true;
	}
}
