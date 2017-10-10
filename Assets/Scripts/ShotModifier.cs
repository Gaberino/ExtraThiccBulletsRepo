using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotModifier : ScriptableObject {

	public SpaceGun myGun;

	public int maxUpgradeLevel = 0; //0 is infinity
	public int currentLevel = 1;
	public float timeToLevelRatio;
	public float bulletLifeTimes = 1f;
	public float bulletSpeeds = 1f;
	public float shotCooldown = 1f;
	public float bulletScale = 1f;
	public Vector2 bulletShootOffset;

	protected Color colorToSet;

	public virtual void InitializeMod(SpaceGun ownerGun){
		myGun = ownerGun;
		colorToSet = myGun.GetComponent<SpriteRenderer>().color;
	}

	public virtual void ModifyAndShoot(float playerLife){}
}

[CreateAssetMenu(menuName = "ShotModifiers/DefaultModifier")]
public class DefaultShotModifier : ShotModifier {

	public int maxUpgradeLevel = 0; //0 is infinity
	public int currentLevel = 1;
	public float timeToLevelRatio = 10;

	public float perLevelSizeBonus = 1;
	public float perLevelCooldownReduction = 1;

	public override void ModifyAndShoot (float playerLife)
	{
		currentLevel = Mathf.RoundToInt(playerLife / timeToLevelRatio);
		if (currentLevel < 1) currentLevel = 1;
		if (maxUpgradeLevel != 0 && currentLevel > maxUpgradeLevel) currentLevel = maxUpgradeLevel;

		float cooldownToSet = shotCooldown - (perLevelCooldownReduction * currentLevel);
		float scaleToSet = bulletScale + (perLevelSizeBonus * currentLevel);

		myGun.ShootBullet(bulletShootOffset, myGun.transform.up * bulletSpeeds, colorToSet, bulletLifeTimes, cooldownToSet, scaleToSet);
	}
}
