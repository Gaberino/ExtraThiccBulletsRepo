using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpriteManager : MonoBehaviour {

	public Sprite[] shipSprites; //must be size 10
	public float perSpriteSizeBuff = .05f;
	private Vector3 originalScale;
	private PlayerMovement myPlayer;
	private SpriteRenderer mySR;

	private int totalPlayerLevel = 0;
	private int lastPlayerLevel = 0;

	// Use this for initialization
	void Start () {
		myPlayer = this.GetComponent<PlayerMovement>();
		mySR = this.GetComponent<SpriteRenderer>();
		originalScale = this.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

		totalPlayerLevel = myPlayer.weapon1.GetLevel(myPlayer.weapExp1) + myPlayer.weapon2.GetLevel(myPlayer.weapExp2);

		if (lastPlayerLevel != totalPlayerLevel && totalPlayerLevel % 2 == 0){
			UpdateSprite();
			lastPlayerLevel = totalPlayerLevel;
		}

	}

	void UpdateSprite(){
		mySR.sprite = shipSprites[(totalPlayerLevel / 2) - 1];
		this.transform.localScale = originalScale * ((totalPlayerLevel / 2) * perSpriteSizeBuff);
	}
}