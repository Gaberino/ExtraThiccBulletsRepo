using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ShotModifiers/SprayFireMod")]
public class SprayFireMod : ShotModifier {

	public float maxAngleOffset = 1f;
	public float perLevelCooldownReduction = 1;

	public override void ModifyAndShoot (float playerLife, SpaceGun originGun, Color bColor)
	{
		currentLevel = Mathf.RoundToInt(playerLife / timeToLevelRatio);
		if (currentLevel < 1) currentLevel = 1;
		if (maxUpgradeLevel != 0 && currentLevel > maxUpgradeLevel) currentLevel = maxUpgradeLevel;

		float cooldownToSet = shotCooldown - (perLevelCooldownReduction * currentLevel);
		float scaleToSet = bulletScale + (perLevelSizeBonus * currentLevel);

		originGun.ShootBullet(bulletShootOffset, (originGun.transform.up * bulletSpeeds) + (originGun.transform.right * Random.Range(-maxAngleOffset, maxAngleOffset)), bColor, bulletLifeTimes, cooldownToSet, scaleToSet, bulletSpriteToSet);
	}
}
