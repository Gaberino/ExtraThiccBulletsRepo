using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotModifier : ScriptableObject {

	public int maxUpgradeLevel = 0; //0 is infinity
	public int currentLevel = 1;
	public float timeToLevelRatio = 2f;
	public float bulletLifeTimes = 1f;
	public float bulletSpeeds = 1f;
	public float shotCooldown = 1f;
	public float bulletScale = 1f;
    public float perLevelSizeBonus = 1f;
    public Vector2 bulletShootOffset;
	public Sprite bulletSpriteToSet;

	public virtual void ModifyAndShoot(float playerLife, SpaceGun originGun, Color bColor){

		currentLevel = Mathf.RoundToInt(playerLife / timeToLevelRatio);
		if (currentLevel < 1) currentLevel = 1;
		if (maxUpgradeLevel != 0 && currentLevel > maxUpgradeLevel) currentLevel = maxUpgradeLevel;
	}

	public virtual int GetLevel(float lifeToMeasure){
		currentLevel = Mathf.RoundToInt(lifeToMeasure / timeToLevelRatio);
		if (currentLevel < 1) currentLevel = 1;
		if (maxUpgradeLevel != 0 && currentLevel > maxUpgradeLevel) currentLevel = maxUpgradeLevel;

		return currentLevel;
	}
}

