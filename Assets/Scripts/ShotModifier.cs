using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotModifier : ScriptableObject {

	public int maxUpgradeLevel = 0; //0 is infinity
	public int currentLevel = 1;
	public float timeToLevelRatio;
	public float bulletLifeTimes = 1f;
	public float bulletSpeeds = 1f;
	public float shotCooldown = 1f;
	public float bulletScale = 1f;
	public Vector2 bulletShootOffset;

	public virtual void ModifyAndShoot(float playerLife, SpaceGun originGun, Color bColor){}
}

