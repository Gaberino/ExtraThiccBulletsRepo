using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGun : MonoBehaviour {

	public Transform bulletPrefab;
	public ShotModifier currentShotMod;
	public Transform sinBulletPrefab;
	public Transform ricochetBulletPrefab;
	private AudioSource shootAudioSource;
	//public AudioClip shootClip;
	public float levelVolumeBonus;
	private float originalVolume;

	private int myOwnerID = 0;
	private float cooldownTime = 1;
	private float cooldownElapsed = 0;

	// Use this for initialization
	void Start () {
		//get the player script player id and set myownerID to it
		myOwnerID = this.GetComponent<PlayerMovement>().playerNumber;
		shootAudioSource = this.GetComponent<AudioSource>();
		originalVolume = shootAudioSource.volume;
	}
	
	// Update is called once per frame
	void Update () {
		if (cooldownElapsed < cooldownTime){
			cooldownElapsed += Time.deltaTime;
		}
	}

	public void ShootBullet(Vector2 spawnOffset, Vector2 moveVector, Color bulletColor, float bulletLife, float cooldown, float scaling, Sprite bulletSprite){
		if (cooldownElapsed >= cooldownTime){
			cooldownElapsed = 0;
			cooldownTime = cooldown;
			this.transform.Find("aim").GetComponent<ShotCooldownVisualizer>().ResetCharge(cooldown);
			this.transform.Find("Forward").GetComponent<ShotCooldownVisualizer>().ResetCharge(cooldown);

			Transform newBullet = Instantiate(bulletPrefab, this.transform.position + this.transform.up * (spawnOffset.y + transform.localScale.y / 2) + this.transform.right * spawnOffset.x, Quaternion.identity);
			newBullet.transform.eulerAngles = this.transform.eulerAngles;
			newBullet.transform.localScale = Vector3.one * scaling;
			SpaceBullet newBB = newBullet.GetComponent<SpaceBullet>();
			newBB.velocity = moveVector;
			newBB.life = bulletLife;
			newBB.ownerID = myOwnerID;

			newBullet.GetComponent<SpriteRenderer>().color = bulletColor;
			newBullet.GetComponent<SpriteRenderer>().sprite = bulletSprite;
			shootAudioSource.volume = originalVolume + (currentShotMod.GetLevel(this.GetComponent<PlayerMovement>().weapExp * levelVolumeBonus));
			shootAudioSource.Play();
		}
	}

	//added a separate method instead of just adding pierce as an option to shootbullet because it won't fuck other peoples work up this way
	public void ShootBullet(Vector2 spawnOffset, Vector2 moveVector, Color bulletColor, float bulletLife, float cooldown, float scaling, Sprite bulletSprite, bool pierce){
		if (cooldownElapsed >= cooldownTime){
			cooldownElapsed = 0;
			cooldownTime = cooldown;
			this.transform.Find("aim").GetComponent<ShotCooldownVisualizer>().ResetCharge(cooldown);
			this.transform.Find("Forward").GetComponent<ShotCooldownVisualizer>().ResetCharge(cooldown);

			Transform newBullet = Instantiate(bulletPrefab, this.transform.position + this.transform.up * spawnOffset.y + this.transform.up * spawnOffset.x, Quaternion.identity);
			newBullet.transform.eulerAngles = this.transform.eulerAngles;
			newBullet.transform.localScale = Vector3.one * scaling;
			SpaceBullet newBB = newBullet.GetComponent<SpaceBullet>();
			newBB.pierceTerrain = pierce;
			newBB.velocity = moveVector;
			newBB.life = bulletLife;
			newBB.ownerID = myOwnerID;

			newBullet.GetComponent<SpriteRenderer>().color = bulletColor;
            newBullet.GetComponent<SpriteRenderer>().sprite = bulletSprite;
            shootAudioSource.volume = originalVolume + (currentShotMod.GetLevel(this.GetComponent<PlayerMovement>().weapExp) * levelVolumeBonus);
			shootAudioSource.Play();
		}
	}

	public void ShootBullet(Vector2 spawnOffset, Vector2 moveVector, Color bulletColor, float bulletLife, float cooldown, float scaling, Sprite bulletSprite, string isSin){
		if (cooldownElapsed >= cooldownTime){
			cooldownElapsed = 0;
			cooldownTime = cooldown;

			this.transform.Find("aim").GetComponent<ShotCooldownVisualizer>().ResetCharge(cooldown);
			this.transform.Find("Forward").GetComponent<ShotCooldownVisualizer>().ResetCharge(cooldown);

			Transform newBullet = Instantiate(sinBulletPrefab, this.transform.position + this.transform.up * spawnOffset.y + this.transform.up * spawnOffset.x, Quaternion.identity);
			newBullet.transform.eulerAngles = this.transform.eulerAngles;
			newBullet.transform.localScale = Vector3.one;
			SinWaveBullet newBB = newBullet.GetComponent<SinWaveBullet>();
			newBB.velocity = moveVector;
			newBB.life = bulletLife;
			newBB.ownerID = myOwnerID;
			newBB.scale = scaling;

			newBullet.GetComponent<SpriteRenderer>().color = bulletColor;
			shootAudioSource.volume = originalVolume + (currentShotMod.GetLevel(this.GetComponent<PlayerMovement>().weapExp) * levelVolumeBonus);
			shootAudioSource.Play();
		}
	}

	public void ShootBullet(Vector2 spawnOffset, Vector2 moveVector, Color bulletColor, float bulletLife, float cooldown, float scaling, Sprite bulletSprite, int ricochetBounces){
		if (cooldownElapsed >= cooldownTime){
			cooldownElapsed = 0;
			cooldownTime = cooldown;

			this.transform.Find("aim").GetComponent<ShotCooldownVisualizer>().ResetCharge(cooldown);
			this.transform.Find("Forward").GetComponent<ShotCooldownVisualizer>().ResetCharge(cooldown);

			Transform newBullet = Instantiate(ricochetBulletPrefab, this.transform.position + this.transform.up * spawnOffset.y + this.transform.up * spawnOffset.x, Quaternion.identity);
			newBullet.transform.eulerAngles = this.transform.eulerAngles;
			newBullet.transform.localScale = Vector3.one;
			RicochetBullet newBB = newBullet.GetComponent<RicochetBullet>();
			newBB.velocity = moveVector;
			newBB.life = bulletLife;
			newBB.ownerID = myOwnerID;
			newBB.bounces = ricochetBounces;

			newBullet.GetComponent<SpriteRenderer>().color = bulletColor;
			shootAudioSource.volume = originalVolume + (currentShotMod.GetLevel(this.GetComponent<PlayerMovement>().weapExp) * levelVolumeBonus);
			shootAudioSource.Play();
		}
	}
}
