using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupScript : MonoBehaviour {

	public bool execute = false;

	public float travelDuration = 1f;
	public float lingerDuration = 1f;
	private float lingerTimer = 0f;
	public float relDistanceToTravel = 1;
	public float scaleToReach = 1;
	private Vector3 startingLocalScale;

	private float travelTimer = 0;

	private RectTransform myRectTrans;
	private Text myText;
	private Color textStartingColor;

	void Start(){
		myRectTrans = this.GetComponent<RectTransform>();

		startingLocalScale = myRectTrans.localScale;
		myText = this.GetComponent<Text>();
		textStartingColor = myText.color;
	}

	// Update is called once per frame
	void Update () {
		if (execute){
			myRectTrans.localPosition = Vector3.Lerp(Vector3.zero, Vector3.up * relDistanceToTravel, travelTimer / travelDuration);

			myRectTrans.localScale = Vector3.Lerp(startingLocalScale, startingLocalScale * scaleToReach, travelTimer / travelDuration);


			travelTimer += Time.deltaTime;

			if (travelTimer > travelDuration) travelTimer = travelDuration;

			if (travelTimer >= travelDuration) {
				Debug.Log("UDOUGSOGOSGUDGYU");
				myText.color = Color.Lerp(textStartingColor, Color.clear, lingerTimer / lingerDuration);

				lingerTimer += Time.deltaTime;
				if (lingerTimer >= lingerDuration) Destroy (this.gameObject);
			}
		}
	}
}
