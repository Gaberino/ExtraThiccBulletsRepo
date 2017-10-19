using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldToWinItem : MonoBehaviour {

	public Transform currentHolderTransform;
	public float lerpSpeed;
	private Vector3 gameStartPos;

	int currentHolderID = 0;

	// Use this for initialization
	void Start () {
		gameStartPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if  (currentHolderTransform != null){
            /*
			if (currentHolderID == 1)
			WinManager.instance.p1HoldTime += Time.deltaTime;
			else if (currentHolderID == 2)
				WinManager.instance.p2HoldTime += Time.deltaTime;
			//drop or respawn check collider active
			if (!currentHolderTransform.GetComponent<Collider2D>().isActiveAndEnabled){
				currentHolderTransform = null;
				currentHolderID = 0;
			}
            */
            this.transform.position = Vector3.Lerp(this.transform.position, currentHolderTransform.position, Time.deltaTime * lerpSpeed);
        }
	}
	void OnTriggerEnter2D(Collider2D col){
        /*
		if (col.tag.Contains ("Player")) {
			if (currentHolderTransform == null) {

				currentHolderTransform = col.transform;
				currentHolderID = col.gameObject.GetComponent<PlayerMovement> ().playerNumber; //may need to change the script being grabbed here
			}
		}
		else if (col.tag.Contains("WinZone")){
			currentHolderID = 0;
			currentHolderTransform = null;
			this.transform.position = gameStartPos;
		}
        */
	}
}
