using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGun : MonoBehaviour {

	public Transform bulletPrefab;
	public ShotModifier currentShotMod;

	private int myOwnerID = 0;
	private float cooldownTime = 1;
	private float cooldownElapsed = 0;

	// Use this for initialization
	void Start () {
		//get the player script player id and set myownerID to it
	}
	
	// Update is called once per frame
	void Update () {
		if (cooldownElapsed < cooldownTime){
			cooldownElapsed += Time.deltaTime;
		}
	}

	public void ShootBullet(Vector2 spawnOffset, Vector2 moveVector, Color bulletColor, float bulletLife, float cooldown, float scaling){
		if (cooldownElapsed > cooldownTime){
			cooldownElapsed = 0;
			cooldownTime = cooldown;

			Transform newBullet = Instantiate(bulletPrefab, new Vector3(this.transform.position.x + (spawnOffset.x * this.transform.right), this.gameObject.transform.position.y + (spawnOffset.y * this.transform.up)), Quaternion.identity);
			SpaceBullet newBB = newBullet.GetComponent<SpaceBullet>();
			newBB.velocity = moveVector;
			newBB.life = bulletLife;
			newBB.ownerID = myOwnerID;

			newBullet.GetComponent<SpriteRenderer>().color = bulletColor;
		}
	}
}
