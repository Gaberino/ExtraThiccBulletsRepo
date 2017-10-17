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
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag.Contains ("Player")) {
			if (currentHolderTransform == null) {

				currentHolderTransform = col.transform;
				currentHolderID = col.gameObject.GetComponent<PlayerMovementInControl> ().playerNumber; //may need to change the script being grabbed here
			}
		}
	}
}
